using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AutoFoco
{
    internal class ProviderAutoFocoUrlComposer : ProviderBaseUrlComposer, IProviderUrlComposer
    {
        #region Constructores
        public ProviderAutoFocoUrlComposer()
        {
            this.CodProvider = enProvider.AutoFoco;
        }
        #endregion

        #region Overrides virtuals
        protected override void TratamientoUrlProvider()
        {
            if (this.UrlBuild.Contains("&page=0"))
                this.UrlBuild = this.UrlBuild.Replace("&page=0", String.Empty);
        }

        protected override int ParsePageProvider(int page)
        {
            var retorno = base.ParsePageProvider(page);
            retorno--;
            return retorno;
        }
        #endregion
    }
}
