using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AlaMaula
{
    internal class ProviderAlaMaulaFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("view"));

                if (elementSearchResult == null)
                    return retorno;

                retorno = elementSearchResult.Descendants("li")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("result pictures")).ToList();
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
                retorno = htmlNode.GetAttributeValue("data-adid", String.Empty);
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
                var itemInfo = htmlNode.Descendants("a")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("href-link"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();
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
                var descripcion = this.GetDescripcion(htmlNode);
                foreach (var parte in descripcion.Split(' '))
                {
                    if (parte.Trim().Length != 4)
                        continue;

                    var anio = default(int);
                    if (int.TryParse(parte.Trim(), out anio))
                    {
                        retorno = anio.ToString();
                        break;
                    }
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
                        && d.Attributes["class"].Value.Contains("description"));

                if (itemInfo == null)
                    return retorno;

                var spanInfo = itemInfo.Descendants("span").FirstOrDefault();
                if (spanInfo == null)
                    return retorno;

                if (!spanInfo.InnerText.ToLower().Contains("km"))
                    return retorno;

                //Intentamos obtener el kilometraje
                var indexTo = spanInfo.InnerText.ToLower().IndexOf("km");
                var indexFrom = indexTo - 8;
                if (indexFrom < 0) indexFrom = 0;

                retorno = itemInfo.InnerText.Substring(indexFrom, indexTo - indexFrom).Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace(" km", String.Empty);
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
                var itemInfo = htmlNode.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("amount"));

                if (itemInfo == null)
                    return retorno;

                retorno = itemInfo.InnerText.Trim();

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
                var itemUbicacion = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("category-location"));

                if (itemUbicacion == null)
                    return retorno;

                var spanUbicacion = itemUbicacion.Descendants("span").FirstOrDefault();
                if (spanUbicacion == null)
                    return retorno;

                retorno = spanUbicacion.InnerText.Trim();

                //Limpiamos información innecesaria
                retorno = retorno.Replace("Publicado en: ", String.Empty);
                retorno = retorno.Replace("Autos , ", String.Empty);
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
                var itemLink = htmlNode.Descendants("a")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("href-link"));

                if (itemLink == null)
                    return retorno;

                retorno = itemLink.GetAttributeValue("href", String.Empty);
                retorno = retorno.Trim();

                //Verificamos que esté completa
                if (!retorno.StartsWith("http://www.alamaula.com"))
                    retorno = String.Format("{0}{1}", "http://www.alamaula.com", retorno);
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
                var itemImg = htmlNode.Descendants("img")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("thumbM"));

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
