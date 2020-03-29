using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.DeAutos
{
    internal class ProviderDeAutosFormatter : IProviderFormatter
    {
        public IEnumerable<HtmlNode> GetItems(HtmlDocument htmlDocument)
        {
            var retorno = new List<HtmlNode>();
            try
            {
                var elementSearchResult = htmlDocument.DocumentNode.Descendants("ul")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("publication-list"));

                if (elementSearchResult == null)
                    return retorno;

                retorno = elementSearchResult.Descendants("li")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("publication-item superpremium")).ToList();
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
                retorno = htmlNode.Descendants("meta")
                            .Where(n => n.Attributes["itemprop"] != null && n.Attributes["itemprop"].Value == "productID")
                            .Select(n => n.Attributes["content"].Value)
                            .FirstOrDefault();
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
                        && d.Attributes["class"].Value.Contains("model-brand"));

                if (itemInfo == null)
                    return retorno;

                var itemInfoMarca = itemInfo.Descendants("h2").FirstOrDefault();
                if (itemInfoMarca == null)
                    return retorno;

                retorno = itemInfoMarca.InnerText.Trim();

                var itemInfoModelo = itemInfo.Descendants("p").FirstOrDefault();
                if (itemInfoModelo == null)
                    return retorno;

                retorno = retorno + " " + itemInfoModelo.InnerText.Trim();
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
                var itemInfoExtra = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("additional-car-info"));

                if (itemInfoExtra == null)
                    return retorno;

                var itemInfoSub = itemInfoExtra.Descendants("span").ToList();
                if (itemInfoSub.Count == 0)
                    return retorno;

                retorno = itemInfoSub[0].InnerText.Trim();
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
                var itemInfoExtra = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("additional-car-info"));

                if (itemInfoExtra == null)
                    return retorno;

                var itemInfoSub = itemInfoExtra.Descendants("span").ToList();
                if (itemInfoSub.Count == 0)
                    return retorno;

                retorno = itemInfoSub[1].InnerText.Trim();

                //Eliminamos información innecesaria
                retorno = retorno.Replace("km", String.Empty);
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
                var itemPrecio = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("price"));

                if (itemPrecio == null)
                    return retorno;

                var itemInfoPrecio = itemPrecio.Descendants("span").FirstOrDefault();
                if (itemInfoPrecio == null)
                    return retorno;

                retorno = itemInfoPrecio.InnerText.Trim();

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
                var desc = htmlNode.Descendants("meta")
                            .Where(n => n.Attributes["itemprop"] != null && n.Attributes["itemprop"].Value == "description")
                            .Select(n => n.Attributes["content"].Value)
                            .FirstOrDefault();

                if (desc.Split('|').Length < 5)
                    return retorno;

                retorno = desc.Split('|')[4].Trim();
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
                var itemActive = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("item active"));

                if (itemActive == null)
                    return retorno;

                var itemDesc = itemActive.Descendants("a").FirstOrDefault();
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
                var itemActive = htmlNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("item active"));

                if (itemActive == null)
                    return retorno;

                var itemImg = itemActive.Descendants("img").FirstOrDefault();
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
