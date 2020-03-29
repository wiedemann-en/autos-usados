using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.PhantomJS;
using BusquedaVehiculos.Infra.Log;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Providers.Base
{
    public class ProviderContentResolver : IProviderContentResolver
    {
        public HtmlDocument GetContentHtml(Uri url)
        {
            //var htmlResult = ExecuterPhantomJS.GetContentHtml(url.ToString());
            var executerPhantomJS = new PhantomJSExe();
            var htmlResult = executerPhantomJS.GetContentHtml(url.ToString());
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlResult);
            return htmlDocument;
        }
    }
}
