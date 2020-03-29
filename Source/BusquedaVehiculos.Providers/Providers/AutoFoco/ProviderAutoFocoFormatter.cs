using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AutoFoco
{
    internal class ProviderAutoFocoFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("usedList half-banner full-item"));

                if (elementSearchResult == null)
                    return retorno;

                var divItemsContainer = elementSearchResult.OwnerDocument.GetElementbyId("featuredUsed");
                if (divItemsContainer == null)
                    return retorno;

                retorno = divItemsContainer.Descendants("article").ToList();
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-image"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemLink = itemInfoGeneral.Descendants("a")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("vehicle-href"));

                if (itemLink == null)
                    return retorno;

                var urlDetalle = itemLink.GetAttributeValue("href", String.Empty);
                if (String.IsNullOrEmpty(urlDetalle))
                    return retorno;

                retorno = urlDetalle.Split('/')[urlDetalle.Split('/').Length - 1];
                retorno = retorno.Trim();
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-info card-content"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemDesc = itemInfoGeneral.Descendants("h2")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("bold size-h6"));

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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-info card-content"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemDesc = itemInfoGeneral.Descendants("h2")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("bold size-h6"));

                if (itemDesc == null)
                    return retorno;

                if (itemDesc.InnerText.Contains("·"))
                    retorno = itemDesc.InnerText.Split('·')[0].Trim();
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-info card-content"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemKilometros = itemInfoGeneral.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("latam-secondary-text text-lighten-2 bold size-small right truncate"));

                if (itemKilometros == null)
                    return retorno;

                retorno = itemKilometros.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("Kms.", String.Empty).Trim();
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-info card-action"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemPrecio = itemInfoGeneral.Descendants("strong")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("size-h5"));

                if (itemPrecio == null)
                    return retorno;

                retorno = itemPrecio.InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("$", String.Empty).Trim();
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-info card-content"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemUbicacion = itemInfoGeneral.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("latam-secondary-text text-lighten-2 bold size-small left truncate"));

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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-image"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemLink = itemInfoGeneral.Descendants("a")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("vehicle-href"));

                if (itemLink == null)
                    return retorno;

                retorno = itemLink.GetAttributeValue("href", String.Empty);
                retorno = retorno.Trim();

                if (!retorno.StartsWith("https://www.autofoco.com"))
                    retorno = String.Format("{0}{1}", "https://www.autofoco.com", retorno);
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
                var itemInfoGeneral = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("card-image"));

                if (itemInfoGeneral == null)
                    return retorno;

                var itemLinkImagen = itemInfoGeneral.Descendants("img")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("image-loader"));

                if (itemLinkImagen == null)
                    return retorno;

                retorno = itemLinkImagen.GetAttributeValue("src", String.Empty);
                retorno = retorno.Trim();
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
