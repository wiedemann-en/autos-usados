using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.DeAutos
{
    internal class ProviderDeAutosPaginator : IProviderPaginator
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
                var itemInfoCantidadRegistros = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("count-info"));

                if (itemInfoCantidadRegistros == null)
                    return retorno;

                var itemCantidadRegistros = itemInfoCantidadRegistros.Descendants("strong").FirstOrDefault();
                if (itemCantidadRegistros == null)
                    return retorno;

                var sarasa = itemCantidadRegistros.InnerText.Trim();
                sarasa = sarasa.Replace(",", String.Empty);

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
                        && d.Attributes["class"].Value.Contains("pagination"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginaActiva = itemInfoPaginas.Descendants("li")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("active"));

                if (itemPaginaActiva == null)
                    return retorno;

                var itemLinkPaginaActiva = itemPaginaActiva.Descendants("a").FirstOrDefault();
                if (itemLinkPaginaActiva == null)
                    return retorno;

                var sarasa = itemLinkPaginaActiva.InnerText.Trim();
                sarasa = sarasa.Replace("(current)", String.Empty);

                if (!String.IsNullOrEmpty(sarasa))
                    int.TryParse(sarasa, out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }
    }
}
