using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.DeAutos;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.DeAutos
{
    public class ProviderDeAutosSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderDeAutosSync()
            : base()
        {
            this.CodProvider = enProvider.DeAutos;
            this.ProviderUrlComposer = new ProviderDeAutosUrlComposer();
            this.ProviderFormatter = new ProviderDeAutosFormatter();
            this.ProviderPaginator = new ProviderDeAutosPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
