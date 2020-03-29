using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.DeMotores
{
    internal class ProviderDeMotoresUrlComposer : ProviderBaseUrlComposer, IProviderUrlComposer
    {
        #region Constructores
        public ProviderDeMotoresUrlComposer()
        {
            this.CodProvider = enProvider.DeMotores;
        }
        #endregion
    }
}
