using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.MercadoLibre
{
    internal class ProviderMercadoLibrePaginator : IProviderPaginator
    {
        public short RowsPerPage
        {
            get { return 48; }
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
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("p")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("page"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemCantidadRegistros = itemInfoPaginas.Descendants("strong").FirstOrDefault();
                if (itemCantidadRegistros == null)
                    return retorno;

                if (!String.IsNullOrEmpty(itemCantidadRegistros.InnerText.Trim()))
                    int.TryParse(itemCantidadRegistros.InnerText.Trim(), out retorno);
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
                        && d.Attributes["class"].Value.Contains("ch-pagination"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginaActual = itemInfoPaginas.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("ch-pagination-current"));

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
