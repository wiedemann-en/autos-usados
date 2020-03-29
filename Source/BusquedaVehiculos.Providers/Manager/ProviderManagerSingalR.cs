using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Interfaces.SignalR;
using BusquedaVehiculos.Providers.AlaMaula;
using BusquedaVehiculos.Providers.AutoFoco;
using BusquedaVehiculos.Providers.Base;
using BusquedaVehiculos.Providers.DeAutos;
using BusquedaVehiculos.Providers.DeMotores;
using BusquedaVehiculos.Providers.MercadoLibre;
using BusquedaVehiculos.Providers.Olx;
using BusquedaVehiculos.Providers.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Manager
{
    public class ProviderManagerSingalR : IProviderManagerSignalR
    {
        #region Atributos privados
        private List<ProviderBaseSignalR> Providers { get; set; }
        #endregion

        #region Atributos IProviderBusquedaSignalR
        public IBusquedaLongRunningTask BusquedaLongRunningTask { get; private set; }
        #endregion

        #region Constructores
        public ProviderManagerSingalR(IBusquedaLongRunningTask busquedaLongRunningTask)
        {
            this.BusquedaLongRunningTask = busquedaLongRunningTask;

            //Inicializamos la lista de providers disponibles
            this.Initialize();
        }
        #endregion

        #region Interfaz pública
        public void EjecutarBusqueda(BusquedaRequestDTO request)
        {
            var retorno = new List<BusquedaResponseDTO>();
            try
            {
                Parallel.ForEach(this.Providers, (itemProvider) =>
                {
                    itemProvider.BuscarVehiculos(request);
                });
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Helpers
        private void Initialize()
        {
            this.Providers = new List<ProviderBaseSignalR>();
            this.Providers.Add(new ProviderAlaMaulaSignalR(this.BusquedaLongRunningTask));
            this.Providers.Add(new ProviderAutoFocoSignalR(this.BusquedaLongRunningTask));
            this.Providers.Add(new ProviderDeAutosSignalR(this.BusquedaLongRunningTask));
            this.Providers.Add(new ProviderDeMotoresSignalR(this.BusquedaLongRunningTask));
            this.Providers.Add(new ProviderMercadoLibreSignalR(this.BusquedaLongRunningTask));
            this.Providers.Add(new ProviderOlxSignalR(this.BusquedaLongRunningTask));
        }
        #endregion
    }
}
