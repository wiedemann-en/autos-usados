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

namespace BusquedaVehiculos.Providers.AutoFoco
{
    public class ProviderAutoFocoSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderAutoFocoSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
        {
            this.CodProvider = enProvider.AutoFoco;
            this.ProviderUrlComposer = new ProviderAutoFocoUrlComposer();
            this.ProviderFormatter = new ProviderAutoFocoFormatter();
            this.ProviderPaginator = new ProviderAutoFocoPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
