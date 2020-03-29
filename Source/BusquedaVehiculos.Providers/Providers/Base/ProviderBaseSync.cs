using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Infra.Log;
using BusquedaVehiculos.Infra.Parametros;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Providers.PhantomJS;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Base
{
    public abstract class ProviderBaseSync : ProviderBase, IProviderBusquedaSync
    {
        #region Constructores
        public ProviderBaseSync()
            : base() { }
        #endregion

        #region IProviderBusquedaSync
        public BusquedaResponseDTO BuscarVehiculos(BusquedaRequestDTO request)
        {
            var retorno = new BusquedaResponseDTO() { CodProvider = this.CodProvider };
            try
            {
                int? currentPage = null;
                int? pagesCount = null;

                //Procesamos el request
                while ((!currentPage.HasValue && !pagesCount.HasValue) || (currentPage.Value < pagesCount.Value))
                {
                    //Procesamos la solicitud paginada
                    var result = this.ProcessUrl(request, ref currentPage, ref pagesCount);
                    retorno.Items.AddRange(result);

                    //Aumentamos de página si no es ambiente de test
                    if (ParametrosAppSetting.ConfigAmbienteTest == "N")
                    {
                        currentPage++;
                    }
                    else
                    {
                        //Cortamos el ciclo
                        currentPage = 1;
                        pagesCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //AppLog.LogMessage("ProviderBaseSync_BuscarVehiculos_exception", BusquedaVehiculos.Infra.Serialization.Serializer.Serialize(ex));
                AppLog.LogMessage("ProviderBaseSync_BuscarVehiculos_exception", ex.Message);
            }
            return retorno;
        }
        #endregion
    }
}
