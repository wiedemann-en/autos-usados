using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderBusquedaSignalR
    {
        /// <summary>
        /// Proceso de búsqueda asincrónica
        /// </summary>
        /// <param name="request"></param>
        void BuscarVehiculos(BusquedaRequestDTO request);
    }
}
