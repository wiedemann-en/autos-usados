using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Interfaces.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderManagerSignalR
    {
        /// <summary>
        /// Notificador de resultados al cliente
        /// </summary>
        IBusquedaLongRunningTask BusquedaLongRunningTask { get; }

        /// <summary>
        /// Proceso de búsqueda asincrónica
        /// </summary>
        /// <param name="request"></param>
        void EjecutarBusqueda(BusquedaRequestDTO request);
    }
}
