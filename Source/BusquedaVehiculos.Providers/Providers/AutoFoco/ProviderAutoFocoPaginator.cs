using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AutoFoco
{
    internal class ProviderAutoFocoPaginator : IProviderPaginator
    {
        public short RowsPerPage
        {
            get { return 20; }
        }

        public int GetPagesCount(HtmlDocument htmlDocument)
        {
            var retorno = default(int);
            try
            {
                var itemInfoPaginas = htmlDocument.DocumentNode.Descendants("ul")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("pagination"));

                if (itemInfoPaginas == null)
                    return retorno;

                var itemPaginas = itemInfoPaginas.Descendants("li")
                    .Where(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("waves-effect")).ToList();

                if ((itemPaginas == null) || (itemPaginas.Count < 3))
                    return retorno;

                var sarasa = itemPaginas[itemPaginas.Count - 2];
                if (sarasa == null)
                    return retorno;

                if (!String.IsNullOrEmpty(sarasa.InnerText.Trim()))
                    int.TryParse(sarasa.InnerText.Trim(), out retorno);
            }
            catch (Exception)
            {
            }
            return retorno;
        }

        public int GetRowsCount(HtmlDocument htmlDocument)
        {
            throw new NotImplementedException();
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

                var itemInfoPaginaActual = itemInfoPaginas.Descendants("li")
                    .LastOrDefault(d => d.Attributes.Contains("class")
                        && d.Attributes["class"].Value.Contains("waves-effect")
                        && !d.Attributes["class"].Value.Contains("active"));

                if (itemInfoPaginaActual == null)
                    return retorno;

                var itemPaginaActual = itemInfoPaginaActual.Descendants("a").FirstOrDefault();
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
