using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.Providers
{
    public interface IProviderUrlComposer
    {
        Uri GetUrlParsed(BusquedaRequestDTO request, int? page = null);
    }
}
