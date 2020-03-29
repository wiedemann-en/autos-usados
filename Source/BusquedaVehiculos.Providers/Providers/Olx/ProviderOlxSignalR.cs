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

namespace BusquedaVehiculos.Providers.Olx
{
    public class ProviderOlxSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderOlxSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
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
