using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.MercadoLibre
{
    internal class ProviderMercadoLibreFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.GetElementbyId("searchResults");
                if (elementSearchResult == null)
                    return retorno;

                retorno = elementSearchResult.Descendants("div")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("rowItem")).ToList();
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetId(HtmlNode htmlNode)
        {
            return htmlNode.Id;
        }

        public String GetDescripcion(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemDesc = htmlNode.Descendants("a").FirstOrDefault();
                if (itemDesc == null)
                    return retorno;
                retorno = itemDesc.InnerText.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetAnioModelo(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemInfo = htmlNode.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("destaque"));

                if (itemInfo == null)
                    return retorno;

                var itemInfoSub = itemInfo.Descendants("strong").FirstOrDefault();
                if (itemInfoSub == null)
                    return retorno;

                retorno = itemInfoSub.InnerText.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetKilometros(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemInfo = htmlNode.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("destaque"));

                if (itemInfo == null)
                    return retorno;

                var itemInfoSub = itemInfo.Descendants("strong").ToList();
                if (itemInfoSub.Count == 0)
                    return retorno;

                retorno = itemInfoSub[1].InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("&nbsp;Km", String.Empty);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetPrecio(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemPrecio = htmlNode.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("ch-price"));

                if (itemPrecio == null)
                    return retorno;

                retorno = itemPrecio.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("$", String.Empty);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetUbicacion(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemUbicacion = htmlNode.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("more-info"));

                if (itemUbicacion == null)
                    return retorno;

                retorno = itemUbicacion.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("&nbsp;", String.Empty);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetUrlDetalle(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemDesc = htmlNode.Descendants("a").FirstOrDefault();
                if (itemDesc == null)
                    return retorno;

                retorno = itemDesc.GetAttributeValue("href", String.Empty);
                retorno = retorno.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetLinkImagen(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemLinkImg = htmlNode.Descendants("a")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("item-link"));

                if (itemLinkImg == null)
                    return retorno;

                var itemImg = itemLinkImg.Descendants("img").FirstOrDefault();
                if (itemImg == null)
                    return retorno;

                retorno = itemImg.GetAttributeValue("src", String.Empty);
                retorno = retorno.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
