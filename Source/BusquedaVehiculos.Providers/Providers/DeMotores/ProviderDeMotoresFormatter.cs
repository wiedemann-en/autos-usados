using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.DeMotores
{
    internal class ProviderDeMotoresFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.DocumentNode.Descendants("ul")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("gal-view"));

                if (elementSearchResult == null)
                    return retorno;

                retorno = elementSearchResult.Descendants("li")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("article")).ToList();
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetId(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemId = htmlNode.Descendants().FirstOrDefault(n => n.Id == "vehicleId");
                if (itemId == null)
                    return retorno;
                retorno = itemId.GetAttributeValue("Value", String.Empty);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public String GetDescripcion(HtmlNode htmlNode)
        {
            var retorno = String.Empty;
            try
            {
                var itemDesc = htmlNode.Descendants("h3").FirstOrDefault();
                if (itemDesc == null)
                    return retorno;
                var itemLink = itemDesc.Descendants("a").FirstOrDefault();
                if (itemLink == null)
                    return retorno;
                retorno = itemLink.InnerText.Trim();
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
                        && d.Attributes["class"].Value.Contains("anio"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();
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
                        && d.Attributes["class"].Value.Contains("km"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace(" Km", String.Empty);
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
                var itemInfo = htmlNode.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("precio"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("$ ", String.Empty);
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
                var itemUbicacion = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("ubicacion"));

                if (itemUbicacion == null)
                    return retorno;

                retorno = itemUbicacion.InnerText.Trim();
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
                var itemDesc = htmlNode.Descendants("h3").FirstOrDefault();
                if (itemDesc == null)
                    return retorno;
                var itemLink = itemDesc.Descendants("a").FirstOrDefault();
                if (itemLink == null)
                    return retorno;

                retorno = itemLink.GetAttributeValue("data-url", String.Empty);
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
                var itemLinkImg = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("content-image-slider"));

                if (itemLinkImg == null)
                    return retorno;

                var itemImg = itemLinkImg.Descendants("img").FirstOrDefault();
                if (itemImg == null)
                    return retorno;

                retorno = itemImg.GetAttributeValue("data-original", String.Empty);
                if (String.IsNullOrEmpty(retorno))
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
