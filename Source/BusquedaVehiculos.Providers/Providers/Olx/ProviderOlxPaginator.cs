using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Olx
{
    internal class ProviderOlxPaginator : IProviderPaginator
    {
        public short RowsPerPage
        {
            get { return 30; }
        }

        public int GetPagesCount(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("div")
                    .LastOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("listing-breadcrumb"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemCantidadPaginas = itemInfoPaginas.Descendants("p").FirstOrDefault();
                if (itemCantidadPaginas == null)
                    return retorno;

                var sarasa = itemCantidadPaginas.InnerText.Trim();
                if (sarasa.Contains("de "))
                    sarasa = sarasa.Split(new string[] { "de " }, StringSplitOptions.None)[1];
                sarasa = sarasa.Replace(".", String.Empty).Trim();

                if (!String.IsNullOrEmpty(sarasa))
                    int.TryParse(sarasa, out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public int GetRowsCount(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("listing-breadcrumb"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemCantidadRegistros = itemInfoPaginas.Descendants("span").LastOrDefault();
                if (itemCantidadRegistros == null)
                    return retorno;

                var sarasa = itemCantidadRegistros.InnerText.Trim();
                if (sarasa.Contains("resultados"))
                    sarasa = sarasa.Split(new string[] { "resultados" }, StringSplitOptions.None)[0];
                sarasa = sarasa.Replace(".", String.Empty).Trim();

                if (!String.IsNullOrEmpty(sarasa))
                    int.TryParse(sarasa, out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public int GetCurrentPage(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("ul")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("items-paginations-numbers"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginaActual = itemInfoPaginas.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("current"));

                if (itemPaginaActual == null)
                    return retorno;

                if (!String.IsNullOrEmpty(itemPaginaActual.InnerText.Trim()))
                    int.TryParse(itemPaginaActual.InnerText.Trim(), out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
