using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Olx
{
    internal class ProviderOlxFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.DocumentNode.Descendants("ul")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-list"));

                if (elementSearchResult == null)
                    return retorno;

                retorno = elementSearchResult.Descendants("li")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("item")).ToList();
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
                var itemLink = htmlNode.Descendants("a").FirstOrDefault();
                if (itemLink == null)
                    return retorno;

                var link = itemLink.GetAttributeValue("href", String.Empty);
                if (link.Split('-').Length <= 0)
                    return retorno;

                var index = link.Split('-').Length - 1;
                retorno = link.Split('-')[index].Trim();
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
                var itemInfo = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-info"));

                if (itemInfo == null)
                    return retorno;

                var itemDetail = itemInfo.Descendants("h3").FirstOrDefault();
                if (itemDetail == null)
                    return retorno;

                retorno = itemDetail.InnerText.Trim();

                //Verificamos si debemos recortar la inforamción
                if (itemDetail.InnerHtml.Contains("<br>"))
                {
                    var indexTo = itemDetail.InnerHtml.IndexOf("<br>");
                    retorno = itemDetail.InnerHtml.Substring(0, indexTo);
                }
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
                var itemInfo = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-info"));

                if (itemInfo == null)
                    return retorno;

                var itemDetail = itemInfo.Descendants("h3").FirstOrDefault();
                if (itemDetail == null)
                    return retorno;

                var descripcion = itemDetail.InnerText.Trim();

                //Verificamos si debemos recortar la inforamción
                if (itemDetail.InnerHtml.Contains("<br>"))
                {
                    var indexFrom = itemDetail.InnerHtml.IndexOf("<br>") + 4;
                    var anio = itemDetail.InnerHtml.Substring(indexFrom);
                    if (anio.Length > 4)
                        anio = anio.Substring(0, 4);
                    retorno = anio;
                }
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
                var itemInfo = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-info"));

                if (itemInfo == null)
                    return retorno;

                var itemDetail = itemInfo.Descendants("h3").FirstOrDefault();
                if (itemDetail == null)
                    return retorno;

                if (itemDetail.InnerText.Split('-').Length <= 0)
                    return retorno;

                var index = itemDetail.InnerText.Split('-').Length - 1;
                retorno = itemDetail.InnerText.Split('-')[index].Trim();

                //Limpiamos la información
                retorno = retorno.Replace("km", String.Empty).Trim();
                retorno = retorno.Replace("\r\n", String.Empty).Trim();
                retorno = retorno.Replace("Negociable", String.Empty).Trim();
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
                var itemInfo = htmlNode.Descendants("p")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-price"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("$", String.Empty);
                retorno = retorno.Replace("\r\n", String.Empty).Trim();
                retorno = retorno.Replace("Negociable", String.Empty).Trim();
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
                var itemUbicacion = htmlNode.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("displayLocation"));

                if (itemUbicacion == null)
                    return retorno;

                retorno = itemUbicacion.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("en ", String.Empty);
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
                var itemLink = htmlNode.Descendants("a").FirstOrDefault();
                if (itemLink == null)
                    return retorno;

                retorno = itemLink.GetAttributeValue("href", String.Empty);
                retorno = retorno.Trim();

                if (!retorno.StartsWith("https:"))
                    retorno = String.Format("https:{0}", retorno);
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
                var itemImg = htmlNode.Descendants("figure")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("tems-image lines"));

                if (itemImg == null)
                    return retorno;

                var itemLinkImg = itemImg.Descendants("img").FirstOrDefault();
                if (itemLinkImg == null)
                    return retorno;

                retorno = itemLinkImg.GetAttributeValue("src", String.Empty);
                retorno = retorno.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
