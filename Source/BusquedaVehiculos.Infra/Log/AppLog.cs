using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace BusquedaVehiculos.Infra.Log
{
    public static class AppLog
    {
        public static void LogMessage(String typeMessage, String message)
        {
            try
            {
                var logFileName = String.Format("{0}_{1}.txt", DateTime.Now.Ticks.ToString(), typeMessage);
                var logFileNameFullPath = String.Format("~/App_Data/Logs/{0}", logFileName);
                logFileNameFullPath = HostingEnvironment.MapPath(logFileNameFullPath);
                if (Directory.Exists(HostingEnvironment.MapPath("~/App_Data/Logs/")))
                {
                    if (!File.Exists(logFileNameFullPath))
                    {
                        var fileStream = File.Create(logFileNameFullPath);
                        byte[] info = new UTF8Encoding(true).GetBytes(message);
                        fileStream.Write(info, 0, info.Length);
                        fileStream.Close();
                    }
                    else
                    {
                        using (var tw = new StreamWriter(logFileNameFullPath, true))
                        {
                            tw.WriteLine(message);
                            tw.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
