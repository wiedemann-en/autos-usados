using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.MercadoLibre;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.MercadoLibre
{
    public class ProviderMercadoLibreSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderMercadoLibreSync()
            : base()
        {
            this.CodProvider = enProvider.MercadoLibre;
            this.ProviderUrlComposer = new ProviderMercadoLibreUrlComposer();
            this.ProviderFormatter = new ProviderMercadoLibreFormatter();
            this.ProviderPaginator = new ProviderMercadoLibrePaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
