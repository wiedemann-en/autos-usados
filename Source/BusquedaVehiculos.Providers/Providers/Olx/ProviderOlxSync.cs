using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.Olx;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.Olx
{
    public class ProviderOlxSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderOlxSync()
            : base()
        {
            this.CodProvider = enProvider.Olx;
            this.ProviderUrlComposer = new ProviderOlxUrlComposer();
            this.ProviderFormatter = new ProviderOlxFormatter();
            this.ProviderPaginator = new ProviderOlxPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
