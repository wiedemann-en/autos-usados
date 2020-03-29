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

namespace BusquedaVehiculos.Providers.DeMotores
{
    public class ProviderDeMotoresSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderDeMotoresSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
        {
            this.CodProvider = enProvider.DeMotores;
            this.ProviderUrlComposer = new ProviderDeMotoresUrlComposer();
            this.ProviderFormatter = new ProviderDeMotoresFormatter();
            this.ProviderPaginator = new ProviderDeMotoresPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
