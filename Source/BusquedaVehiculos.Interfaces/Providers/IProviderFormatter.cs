using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderFormatter
    {
        IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument);
        String GetId(HtmlNode htmlNode);
        String GetDescripcion(HtmlNode htmlNode);
        String GetAnioModelo(HtmlNode htmlNode);
        String GetKilometros(HtmlNode htmlNode);
        String GetPrecio(HtmlNode htmlNode);
        String GetUbicacion(HtmlNode htmlNode);
        String GetUrlDetalle(HtmlNode htmlNode);
        String GetLinkImagen(HtmlNode htmlNode);
    }
}
