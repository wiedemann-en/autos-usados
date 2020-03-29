using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Model;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Manager
{
    public class ProviderDisponible : IProviderDisponible
    {
        #region IProviderDisponible
        public List<String> GetProvidersDisponibles(BusquedaRequestDTO request)
        {
            var retorno = enProvider.GetProviders();
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Provincia, request.CodVehiculoProvincia);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Marca, request.CodVehiculoMarca);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Modelo, request.CodVehiculoSubMarca);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Color, request.CodVehiculoColor);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Combustible, request.CodVehiculoCombustible);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Direccion, request.CodVehiculoDireccion);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Puertas, request.CodVehiculoPuerta);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Segmento, request.CodVehiculoSegmento);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Traccion, request.CodVehiculoTraccion);
            retorno = this.VerificarItemProvider(retorno, enCatalogo.Transmision, request.CodVehiculoTransmision);
            return retorno;
        }
        #endregion

        #region Helpers
        private List<String> VerificarItemProvider(List<String> providers, String codCatalogo, String codItemConv)
        {
            var retorno = providers.ToList();
            try
            {
                if (String.IsNullOrEmpty(codItemConv))
                    return retorno;

                using (var dbContext = new ModelContext())
                {
                    foreach (var itemProvider in providers)
                    {
                        var poseeItems = false;
                        if (codCatalogo == enCatalogo.Modelo)
                        {
                            poseeItems = dbContext.ProviderCatalogoitemConvDataSet.Any(x =>
                                x.CodProvider == itemProvider &&
                                x.CodCatalogo == codCatalogo &&
                                x.CodItemConv.Contains(codItemConv));
                        }
                        else
                        {
                            poseeItems = dbContext.ProviderCatalogoitemConvDataSet.Any(x =>
                                x.CodProvider == itemProvider &&
                                x.CodCatalogo == codCatalogo &&
                                x.CodItemConv == codItemConv);
                        }

                        //Si no posee ítems eliminamos el provider
                        if (!poseeItems)
                            retorno.Remove(itemProvider);
                    }
                }
            }
            catch (Exception)
            {
            }
            return retorno;
        }
        #endregion
    }
}
