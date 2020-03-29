using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderBusquedaSync
    {
        /// <summary>
        /// Proceso de búsqueda sincrónica
        /// </summary>
        /// <param name="request"></param>
        BusquedaResponseDTO BuscarVehiculos(BusquedaRequestDTO request);
    }
}
