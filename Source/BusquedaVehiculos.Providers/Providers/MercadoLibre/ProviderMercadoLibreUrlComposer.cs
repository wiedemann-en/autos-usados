using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.MercadoLibre
{
    internal class ProviderMercadoLibreUrlComposer : ProviderBaseUrlComposer, IProviderUrlComposer
    {
        #region Constructores
        public ProviderMercadoLibreUrlComposer()
        {
            this.CodProvider = enProvider.MercadoLibre;
        }
        #endregion

        #region Overrides virtuals
        protected override int ParsePageProvider(int page)
        {
            var retorno = base.ParsePageProvider(page);
            if (page > 1)
                retorno = ((retorno * 48) + 1);
            return retorno;
        }
        #endregion
    }
}
