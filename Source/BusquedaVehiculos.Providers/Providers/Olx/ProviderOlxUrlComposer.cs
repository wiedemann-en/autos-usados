using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Olx
{
    internal class ProviderOlxUrlComposer : ProviderBaseUrlComposer, IProviderUrlComposer
    {
        #region Constructores
        public ProviderOlxUrlComposer()
        {
            this.CodProvider = enProvider.Olx;
        }
        #endregion

        #region Overrides virtuals
        protected override void TratamientoUrlProvider()
        {
            if (this.UrlBuild.Contains("-p-1"))
                this.UrlBuild = this.UrlBuild.Replace("-p-1", String.Empty);
        }
        #endregion
    }
}
