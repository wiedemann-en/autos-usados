using BusquedaVehiculos.Infra.Exceptions;
using BusquedaVehiculos.Infra.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.PhantomJS
{
    public class PhantomJS : IDisposable
    {
        #region Atributos privados
        private List<string> errorLines = new List<string>();
        private Process PhantomJsProcess;
        #endregion

        #region Atributos públicos
        public string ToolPath { get; set; }
        public string TempFilesPath { get; set; }
        public string PhantomJsExeName { get; set; }
        public string CustomArgs { get; set; }
        public ProcessPriorityClass ProcessPriority { get; set; }
        public TimeSpan? ExecutionTimeout { get; set; }
        #endregion

        #region Eventos
        public event EventHandler<DataReceivedEventArgs> OutputReceived;
        public event EventHandler<DataReceivedEventArgs> ErrorReceived;
        #endregion

        #region Constructores
        public PhantomJS()
        {
            this.ToolPath = this.ResolveAppBinPath();
            this.PhantomJsExeName = "phantomjs.exe";
            this.ProcessPriority = ProcessPriorityClass.Normal;
        }
        #endregion

        #region Interfaz pública
        public void Run(string jsFile, string[] jsArgs)
        {
            this.Run(jsFile, jsArgs, (Stream)null, (Stream)null);
        }

        public void Run(string jsFile, string[] jsArgs, Stream inputStream, Stream outputStream)
        {
            if (jsFile == null)
                throw new ArgumentNullException("jsFile");
            this.RunInternal(jsFile, jsArgs, inputStream, outputStream);
            try
            {
                this.WaitProcessForExit();
                this.CheckExitCode(this.PhantomJsProcess.ExitCode, this.errorLines);
            }
            finally
            {
                this.PhantomJsProcess.Close();
                this.PhantomJsProcess = (Process)null;
            }
        }

        public Task<bool> RunAsync(string jsFile, string[] jsArgs)
        {
            if (jsFile == null)
                throw new ArgumentNullException("jsFile");
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Action handleExit = (Action)(() =>
            {
                try
                {
                    this.CheckExitCode(this.PhantomJsProcess.ExitCode, this.errorLines);
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
                finally
                {
                    this.PhantomJsProcess.Close();
                    this.PhantomJsProcess = (Process)null;
                }
            });
            this.RunInternal(jsFile, jsArgs, (Stream)null, (Stream)null);
            this.PhantomJsProcess.Exited += (EventHandler)((sender, args) => handleExit());
            if (this.PhantomJsProcess.HasExited)
                handleExit();
            return tcs.Task;
        }

        public void RunScript(string javascriptCode, string[] jsArgs)
        {
            this.RunScript(javascriptCode, jsArgs, (Stream)null, (Stream)null);
        }

        public void RunScript(string javascriptCode, string[] jsArgs, Stream inputStream, Stream outputStream)
        {
            string str = Path.Combine(this.GetTempPath(), "phantomjs-" + Path.GetRandomFileName() + ".js");
            try
            {
                File.WriteAllBytes(str, Encoding.UTF8.GetBytes(javascriptCode));
                this.Run(str, jsArgs, inputStream, outputStream);
            }
            finally
            {
                this.DeleteFileIfExists(str);
            }
        }

        public Task RunScriptAsync(string javascriptCode, string[] jsArgs)
        {
            string tmpJsFilePath = Path.Combine(this.GetTempPath(), "phantomjs-" + Path.GetRandomFileName() + ".js");
            File.WriteAllBytes(tmpJsFilePath, Encoding.UTF8.GetBytes(javascriptCode));
            try
            {
                Task<bool> task = this.RunAsync(tmpJsFilePath, jsArgs);
                task.ContinueWith((Action<Task<bool>>)(t => this.DeleteFileIfExists(tmpJsFilePath)), TaskContinuationOptions.ExecuteSynchronously);
                return (Task)task;
            }
            catch
            {
                this.DeleteFileIfExists(tmpJsFilePath);
                throw;
            }
        }

        public void WriteLine(string s)
        {
            if (this.PhantomJsProcess == null)
                throw new InvalidOperationException("PhantomJS is not running");
            this.PhantomJsProcess.StandardInput.WriteLine(s);
            this.PhantomJsProcess.StandardInput.Flush();
        }

        public void WriteEnd()
        {
            this.PhantomJsProcess.StandardInput.Close();
        }

        public void Abort()
        {
            this.EnsureProcessStopped();
        }
        #endregion

        #region Helpers
        private string ResolveAppBinPath()
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = assembly.GetType("System.Web.HttpRuntime", false);
                if (type != (Type)null)
                {
                    PropertyInfo property1 = type.GetProperty("AppDomainId", BindingFlags.Static | BindingFlags.Public);
                    if (!(property1 == (PropertyInfo)null) && property1.GetValue((object)null, (object[])null) != null)
                    {
                        PropertyInfo property2 = type.GetProperty("BinDirectory", BindingFlags.Static | BindingFlags.Public);
                        if (property2 != (PropertyInfo)null)
                        {
                            object obj = property2.GetValue((object)null, (object[])null);
                            if (obj is string)
                            {
                                str = (string)obj;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                }
            }
            return str;
        }

        private string GetTempPath()
        {
            if (!string.IsNullOrEmpty(this.TempFilesPath) && !Directory.Exists(this.TempFilesPath))
                Directory.CreateDirectory(this.TempFilesPath);
            return this.TempFilesPath ?? Path.GetTempPath();
        }

        private void DeleteFileIfExists(string filePath)
        {
            if (filePath == null)
                return;
            if (!File.Exists(filePath))
                return;
            try
            {
                File.Delete(filePath);
            }
            catch
            {
            }
        }

        private string PrepareCmdArg(string arg)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('"');
            stringBuilder.Append(arg.Replace("\"", "\\\""));
            stringBuilder.Append('"');
            return stringBuilder.ToString();
        }

        private void RunInternal(string jsFile, string[] jsArgs, Stream inputStream, Stream outputStream)
        {
            this.errorLines.Clear();
            try
            {
                string str1 = Path.Combine(this.ToolPath, this.PhantomJsExeName);
                if (!File.Exists(str1))
                    throw new FileNotFoundException("Cannot find PhantomJS: " + str1);
                StringBuilder stringBuilder = new StringBuilder();
                if (!string.IsNullOrEmpty(this.CustomArgs))
                    stringBuilder.AppendFormat(" {0} ", (object)this.CustomArgs);
                stringBuilder.AppendFormat(" {0}", (object)this.PrepareCmdArg(jsFile));
                if (jsArgs != null)
                {
                    foreach (string str2 in jsArgs)
                        stringBuilder.AppendFormat(" {0}", (object)this.PrepareCmdArg(str2));
                }
                ProcessStartInfo processStartInfo = new ProcessStartInfo(str1, stringBuilder.ToString());
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.WorkingDirectory = Path.GetDirectoryName(this.ToolPath);
                processStartInfo.RedirectStandardInput = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                this.PhantomJsProcess = new Process();
                this.PhantomJsProcess.StartInfo = processStartInfo;
                this.PhantomJsProcess.EnableRaisingEvents = true;
                this.PhantomJsProcess.Start();
                if (this.ProcessPriority != ProcessPriorityClass.Normal)
                    this.PhantomJsProcess.PriorityClass = this.ProcessPriority;
                this.PhantomJsProcess.ErrorDataReceived += (DataReceivedEventHandler)((o, args) =>
                {
                    if (args.Data == null)
                        return;
                    this.errorLines.Add(args.Data);
                    if (this.ErrorReceived == null)
                        return;
                    this.ErrorReceived((object)this, args);
                });
                this.PhantomJsProcess.BeginErrorReadLine();
                if (outputStream == null)
                {
                    this.PhantomJsProcess.OutputDataReceived += (DataReceivedEventHandler)((o, args) =>
                    {
                        if (this.OutputReceived == null)
                            return;
                        this.OutputReceived((object)this, args);
                    });
                    this.PhantomJsProcess.BeginOutputReadLine();
                }
                if (inputStream != null)
                    this.CopyToStdIn(inputStream);
                if (outputStream == null)
                    return;
                this.ReadStdOutToStream(this.PhantomJsProcess, outputStream);
            }
            catch (Exception ex)
            {
                //AppLog.LogMessage("phantomjsnew_exception", ex.ToMessageAndCompleteStackTrace());
                this.EnsureProcessStopped();
                throw new Exception("Cannot execute PhantomJS: " + ex.Message, ex);
            }
        }

        protected void CopyToStdIn(Stream inputStream)
        {
            byte[] buffer = new byte[8192];
            while (true)
            {
                int count = inputStream.Read(buffer, 0, buffer.Length);
                if (count > 0)
                {
                    this.PhantomJsProcess.StandardInput.BaseStream.Write(buffer, 0, count);
                    this.PhantomJsProcess.StandardInput.BaseStream.Flush();
                }
                else
                    break;
            }
            this.PhantomJsProcess.StandardInput.Close();
        }

        private void WaitProcessForExit()
        {
            bool hasValue = this.ExecutionTimeout.HasValue;
            if (hasValue)
                this.PhantomJsProcess.WaitForExit((int)this.ExecutionTimeout.Value.TotalMilliseconds);
            else
                this.PhantomJsProcess.WaitForExit();
            if (this.PhantomJsProcess == null)
                throw new PhantomJSException(-1, "FFMpeg process was aborted");
            if (hasValue && !this.PhantomJsProcess.HasExited)
            {
                this.EnsureProcessStopped();
                throw new PhantomJSException(-2, string.Format("FFMpeg process exceeded execution timeout ({0}) and was aborted", (object)this.ExecutionTimeout));
            }
        }

        private void EnsureProcessStopped()
        {
            if (this.PhantomJsProcess == null)
                return;
            if (this.PhantomJsProcess.HasExited)
                return;
            try
            {
                this.PhantomJsProcess.Kill();
                this.PhantomJsProcess.Dispose();
                this.PhantomJsProcess = (Process)null;
            }
            catch (Exception ex)
            {
            }
        }

        private void ReadStdOutToStream(Process proc, Stream outputStream)
        {
            byte[] buffer = new byte[32768];
            int count;
            while ((count = proc.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                outputStream.Write(buffer, 0, count);
        }

        private void CheckExitCode(int exitCode, List<string> errLines)
        {
            if (exitCode != 0)
                throw new PhantomJSException(exitCode, string.Join("\n", errLines.ToArray()));
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            this.EnsureProcessStopped();
        }
        #endregion
    }
}
