using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.SignalR;
using BusquedaVehiculos.Providers.Base;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Providers.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.DeAutos
{
    public class ProviderDeAutosSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderDeAutosSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
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
