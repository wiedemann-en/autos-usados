using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderManagerSync
    {
        /// <summary>
        /// Proceso de búsqueda sincrónica
        /// </summary>
        /// <param name="request"></param>
        List<BusquedaResponseDTO> EjecutarBusqueda(BusquedaRequestDTO request);
    }
}
