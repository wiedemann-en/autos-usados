using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Infra.Exceptions;
using BusquedaVehiculos.Infra.Log;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Interfaces.SignalR;
using BusquedaVehiculos.Providers.PhantomJS;
using BusquedaVehiculos.Providers.SignalR;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Base
{
    public abstract class ProviderBaseSignalR : ProviderBase, IProviderBusquedaSignalR
    {
        #region Atributos públicos
        public IBusquedaLongRunningTask BusquedaLongRunningTask { get; set; }
        #endregion

        #region Constructores
        public ProviderBaseSignalR(IBusquedaLongRunningTask busquedaLongRunningTask)
            : base()
        {
            this.BusquedaLongRunningTask = busquedaLongRunningTask;
        }
        #endregion

        #region IProviderBusquedaAsync
        public void BuscarVehiculos(BusquedaRequestDTO request)
        {
            try
            {
                int? currentPage = null;
                int? pagesCount = null;

                //Procesamos el request
                while ((!currentPage.HasValue && !pagesCount.HasValue) || (currentPage.Value < pagesCount.Value))
                {
                    //Procesamos la solicitud paginada
                    var result = this.ProcessUrl(request, ref currentPage, ref pagesCount);
                    var retorno = new BusquedaResponseDTO();
                    retorno.CodProvider = this.CodProvider;
                    retorno.Items = result;

                    //Notificamos el resultado
                    this.BusquedaLongRunningTask.Report(retorno);

                    //Aumentamos de página
                    currentPage++;
                }
            }
            catch (Exception ex)
            {
                //AppLog.LogMessage("ProviderBaseSignalR_BuscarVehiculos_exception", BusquedaVehiculos.Infra.Serialization.Serializer.Serialize(ex));
                //AppLog.LogMessage("ProviderBaseSignalR_BuscarVehiculos_exception", ex.ToMessageAndCompleteStackTrace());
            }
        }
        #endregion
    }
}
