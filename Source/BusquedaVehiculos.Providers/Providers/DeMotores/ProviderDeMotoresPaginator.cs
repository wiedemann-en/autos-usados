using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.DeMotores
{
    internal class ProviderDeMotoresPaginator : IProviderPaginator
    {
        public short RowsPerPage
        {
            get { return 50; }
        }

        public int GetPagesCount(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("pages_01"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginas = itemInfoPaginas.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("paginas"));

                if (itemPaginas == null)
                    return retorno;

                var sarasa = itemPaginas.InnerText.Trim();
                sarasa = sarasa.Replace("Página ", String.Empty);
                sarasa = sarasa.Replace(" de ", "@");

                if (sarasa.Split('@').Length == 2)
                    int.TryParse(sarasa.Split('@')[1], out retorno);
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
                var itemInfoCantidadRegistros = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("results_count mrs"));

                if (itemInfoCantidadRegistros == null)
                    return retorno;

                var itemCantidadRegistros = itemInfoCantidadRegistros.Descendants("strong").FirstOrDefault();
                if (itemCantidadRegistros == null)
                    return retorno;

                var sarasa = itemCantidadRegistros.InnerText.Trim();
                sarasa = sarasa.Replace(".", String.Empty);

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
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("pages_01"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginas = itemInfoPaginas.Descendants("span")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("paginas"));

                if (itemPaginas == null)
                    return retorno;

                var sarasa = itemPaginas.InnerText.Trim();
                sarasa = sarasa.Replace("Página ", String.Empty);
                sarasa = sarasa.Replace(" de ", "@");

                if (sarasa.Split('@').Length == 2)
                    int.TryParse(sarasa.Split('@')[0], out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
