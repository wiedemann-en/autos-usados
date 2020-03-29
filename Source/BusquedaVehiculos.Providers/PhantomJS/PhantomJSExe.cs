using BusquedaVehiculos.Infra.Exceptions;
using BusquedaVehiculos.Infra.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace BusquedaVehiculos.Providers.PhantomJS
{
    internal class PhantomJSExe
    {
        #region Constantes
        private const String KScriptJS = @"
		var system = require('system');
		var page = require('webpage').create();
		page.open('{0}', function() {
			system.stdout.writeLine(page.content);
			phantom.exit();
		});";
        #endregion

        #region Interfaz pública
        internal String GetContentHtml(String url)
        {
            var htmlResult = String.Empty;
            //var phantomJS = new PhantomJS();
            var phantomJS = new PhantomJS();
            try
            {
                phantomJS.OutputReceived += (sender, e) =>
                {
                    //TODO: Implementar
                };
                phantomJS.ErrorReceived += (sender, e) =>
                {
                    //TODO: Implementar
                    AppLog.LogMessage("phantomjserror", e.Data);
                };

                using (var outMemoryStream = new MemoryStream())
                {
                    //Cargamos el contenido de la página
                    //phantomJS.RunScript(String.Format(KScriptJS, this.UrlBase), null, null, outMemoryStream);

                    //Cargamos el contenido de la página
                    var scriptJS = @"
		            var system = require('system');
		            var page = require('webpage').create();
		            page.open('" + url + @"', function() {
			            system.stdout.writeLine(page.content);
			            phantom.exit();
		            });";
                    phantomJS.RunScript(scriptJS, null, null, outMemoryStream);

                    outMemoryStream.Position = 0;
                    using (var streamReader = new StreamReader(outMemoryStream))
                    {
                        htmlResult = streamReader.ReadToEnd();
                        streamReader.Close();
                    }

                    //Traceamos los mensajes de html retornados
                    AppLog.LogMessage("htmlresult", htmlResult);

                    //Liberamos los recursos utilizados en memoria
                    outMemoryStream.Close();
                }
            }
            catch (Exception ex)
            {
                //TODO: Implementar mecanismo de log
                //AppLog.LogMessage("phantomjsexception", BusquedaVehiculos.Infra.Serialization.Serializer.Serialize(ex));
                //AppLog.LogMessage("phantomjsexception", ex.ToMessageAndCompleteStackTrace());
            }
            finally
            {
                //Nos aseguramos que phantomjs.exe esté detenido
                phantomJS.Abort();
            }
            return htmlResult;
        }
        #endregion
    }
}
