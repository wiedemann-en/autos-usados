using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.DeMotores;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.DeMotores
{
    public class ProviderDeMotoresSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderDeMotoresSync()
            : base()
        {
            this.CodProvider = enProvider.DeMotores;
            this.ProviderUrlComposer = new ProviderDeMotoresUrlComposer();
            this.ProviderFormatter = new ProviderDeMotoresFormatter();
            this.ProviderPaginator = new ProviderDeMotoresPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
