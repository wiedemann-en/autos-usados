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

namespace BusquedaVehiculos.Providers.AlaMaula
{
    public class ProviderAlaMaulaSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderAlaMaulaSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
        {
            this.CodProvider = enProvider.AlaMaula;
            this.ProviderUrlComposer = new ProviderAlaMaulaUrlComposer();
            this.ProviderFormatter = new ProviderAlaMaulaFormatter();
            this.ProviderPaginator = new ProviderAlaMaulaPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
