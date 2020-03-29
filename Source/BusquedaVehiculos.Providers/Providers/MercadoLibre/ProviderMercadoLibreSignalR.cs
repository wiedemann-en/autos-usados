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

namespace BusquedaVehiculos.Providers.MercadoLibre
{
    public class ProviderMercadoLibreSignalR : ProviderBaseSignalR
    {
        #region Constructores
        public ProviderMercadoLibreSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base(busquedaLongRunningTask)
        {
            this.CodProvider = enProvider.MercadoLibre;
            this.ProviderUrlComposer = new ProviderMercadoLibreUrlComposer();
            this.ProviderFormatter = new ProviderMercadoLibreFormatter();
            this.ProviderPaginator = new ProviderMercadoLibrePaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
