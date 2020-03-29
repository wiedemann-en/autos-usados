using BusquedaVehiculos.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using HtmlAgilityPack;
using BusquedaVehiculos.Providers.AlaMaula;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Providers.Providers.Base;

namespace BusquedaVehiculos.Providers.AlaMaula
{
    public class ProviderAlaMaulaSync : ProviderBaseSync
    {
        #region Constructores
        public ProviderAlaMaulaSync()
            : base()
        {
            this.CodProvider = enProvider.AlaMaula;
            this.ProviderUrlComposer = new ProviderAlaMaulaUrlComposer();
            this.ProviderFormatter = new ProviderAlaMaulaFormatter();
            this.ProviderPaginator = new ProviderAlaMaulaPaginator();
            this.ProviderContentResolver = new ProviderContentResolver();
        }
        #endregion
    }
}
