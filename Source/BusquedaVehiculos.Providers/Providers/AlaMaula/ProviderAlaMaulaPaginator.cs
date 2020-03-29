using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AlaMaula
{
    internal class ProviderAlaMaulaPaginator : IProviderPaginator
    {
        public short RowsPerPage
        {
            get { return 23; }
        }

        public int GetPagesCount(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var cantidadRegistros = this.GetRowsCount(htmlDocument);
                retorno = cantidadRegistros / this.RowsPerPage;
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
                        && d.Attributes["class"].Value.Contains("breadcrumbs"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemCantidadRegistros = itemInfoPaginas.Descendants("span")
                    .LastOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("num"));

                if (itemCantidadRegistros == null)
                    return retorno;

                var sarasa = itemCantidadRegistros.InnerText.Trim();
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
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("pagination"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginaActual = itemInfoPaginas.Descendants("span")
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
