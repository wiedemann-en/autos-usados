using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Interfaces.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.SignalR
{
    public class BusquedaJob : BusquedaLongRunningTask, IBusquedaJob
    {
        #region Atributos públicos
        public String Id { get; private set; }

        private readonly BusquedaRequestDTO Request;
        private readonly IProviderManagerSignalR ProviderManager;
        #endregion

        #region Constructores
        public BusquedaJob(BusquedaRequestDTO request, IProviderManagerSignalR providerManager)
            : this(Guid.NewGuid().ToString(), request, providerManager)
        {
        }

        public BusquedaJob(String id, BusquedaRequestDTO request, IProviderManagerSignalR providerManager)
        {
            this.Id = id;
            this.Request = request;
            this.ProviderManager = providerManager;
        }
        #endregion

        #region Interfaz pública
        public void Run()
        {
            this.ProviderManager.BusquedaLongRunningTask.ProgressChanged += Busqueda_ReportProgress;
            this.ProviderManager.BusquedaLongRunningTask.Completed += Busqueda_ReportComplete;
            this.ProviderManager.EjecutarBusqueda(this.Request);
        }
        #endregion

        #region Eventos
        private void Busqueda_ReportProgress(object sender, IProgressEventArgs e)
        {
            this.OnProgressChanged(e);
        }

        private void Busqueda_ReportComplete(object sender, IProgressEventArgs e)
        {
            this.Complete();
        }
        #endregion
    }
}
