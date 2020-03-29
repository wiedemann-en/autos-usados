using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Model;
using BusquedaVehiculos.Contracts.Enums;
using System.Text.RegularExpressions;
using BusquedaVehiculos.Model.DbModel;
using BusquedaVehiculos.Providers.Providers.Base;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.AlaMaula
{
    internal class ProviderAlaMaulaUrlComposer : ProviderBaseUrlComposer, IProviderUrlComposer
    {
        #region Constructores
        public ProviderAlaMaulaUrlComposer()
        {
            this.CodProvider = enProvider.AlaMaula;
        }
        #endregion

        #region Overrides virtuals
        protected override void TratamientoUrlProvider()
        {
            var cantidadFiltros = 0;
            if (!this.UrlBuild.Contains(String.Format("[{0}]", enComponenteUrl.FiltroMarca)))
                cantidadFiltros++;
            if (!this.UrlBuild.Contains(String.Format("[{0}]", enComponenteUrl.FiltroModelo)))
                cantidadFiltros++;
            if (!this.UrlBuild.Contains(String.Format("[{0}]", enComponenteUrl.FiltroCombustible)))
                cantidadFiltros++;
            if (!this.UrlBuild.Contains(String.Format("[{0}]", enComponenteUrl.FiltroColor)))
                cantidadFiltros++;
            if (!this.UrlBuild.Contains(String.Format("[{0}]", enComponenteUrl.FiltroCondicion)))
                cantidadFiltros++;

            if (cantidadFiltros > 0)
            {
                this.UrlBuild = this.UrlBuild.Replace("[CANTIDAD_FILTROS]", String.Format("a{0}", cantidadFiltros));
            }
            else
            {
                this.UrlBuild = this.UrlBuild.Replace("[CANTIDAD_FILTROS]", String.Empty);
            }

            if (this.UrlBuild.Contains("page-1/"))
                this.UrlBuild = this.UrlBuild.Replace("page-1/", String.Empty);
        }
        #endregion
    }
}
