using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderContentResolver
    {
        HtmlDocument GetContentHtml(Uri url);
    }
}
