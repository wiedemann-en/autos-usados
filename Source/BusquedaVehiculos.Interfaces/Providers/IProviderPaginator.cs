using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderPaginator
    {
        Int16 RowsPerPage { get; }
        Int32 GetCurrentPage(HtmlDocument htmlDocument);
        Int32 GetPagesCount(HtmlDocument htmlDocument);
        Int32 GetRowsCount(HtmlDocument htmlDocument);
    }
}
