using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.AutoFoco;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.AutoFoco
{
    public class ProviderAutoFocoSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderAutoFocoSync()
            : base()
        {
            this.CodProvider = enProvider.AutoFoco;
            this.ProviderUrlComposer = new ProviderAutoFocoUrlComposer();
            this.ProviderFormatter = new ProviderAutoFocoFormatter();
            this.ProviderPaginator = new ProviderAutoFocoPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
