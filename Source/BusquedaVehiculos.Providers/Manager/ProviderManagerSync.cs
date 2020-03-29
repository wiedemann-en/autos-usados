using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Providers.AlaMaula;
using BusquedaVehiculos.Providers.AutoFoco;
using BusquedaVehiculos.Providers.Base;
using BusquedaVehiculos.Providers.DeAutos;
using BusquedaVehiculos.Providers.DeMotores;
using BusquedaVehiculos.Providers.MercadoLibre;
using BusquedaVehiculos.Providers.Olx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Manager
{
    public class ProviderManagerSync : IProviderManagerSync
    {
        #region Atributos privados
        private List<ProviderBaseSync> Providers { get; set; }
        #endregion

        #region Constructores
        public ProviderManagerSync()
        {
            //Inicializamos la lista de providers disponibles
            this.Initialize();
        }
        #endregion

        #region Interfaz pública
        public List<BusquedaResponseDTO> EjecutarBusqueda(BusquedaRequestDTO request)
        {
            var retorno = new List<BusquedaResponseDTO>();
            try
            {
                //TODO: Poner un Paralell
                foreach (var itemProvider in this.Providers)
                {
                    //Agregamos a la lista de resultados
                    var resultado = itemProvider.BuscarVehiculos(request);
                    retorno.Add(resultado);
                }
            }
            catch (Exception)
            {
            }
            return retorno;
        }
        #endregion

        #region Helpers
        private void Initialize()
        {
            this.Providers = new List<ProviderBaseSync>();
            this.Providers.Add(new ProviderAlaMaulaSync());
            this.Providers.Add(new ProviderAutoFocoSync());
            this.Providers.Add(new ProviderDeAutosSync());
            this.Providers.Add(new ProviderDeMotoresSync());
            this.Providers.Add(new ProviderMercadoLibreSync());
            this.Providers.Add(new ProviderOlxSync());
        }
        #endregion
    }
}
