using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Infra.Exceptions;
using BusquedaVehiculos.Infra.Log;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Providers.PhantomJS;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Base
{
    public abstract class ProviderBase
    {
        #region Atributos protected
        protected String CodProvider { get; set; }
        protected IProviderUrlComposer ProviderUrlComposer { get; set; }
        protected IProviderFormatter ProviderFormatter { get; set; }
        protected IProviderPaginator ProviderPaginator { get; set; }
        protected IProviderContentResolver ProviderContentResolver { get; set; }
        #endregion

        #region Constructores
        public ProviderBase()
        {
        }
        #endregion

        #region Interfaz
        protected List<BusquedaResponseItemDTO> ProcessUrl(BusquedaRequestDTO request, ref int? currentPage, ref int? pagesCount)
        {
            var retorno = new List<BusquedaResponseItemDTO>();
            try
            {
                //Armamos la url
                var url = this.ProviderUrlComposer.GetUrlParsed(request, currentPage);

                //Obtenemos el html con el resultado de la búsqueda
                var htmlDocument = this.ProviderContentResolver.GetContentHtml(url);

                //Mapeamos la respuesta al formato estándar
                retorno = this.MapResponse(htmlDocument);

                //Determinamos paginación
                //currentPage = this.ProviderPaginator.GetCurrentPage(htmlDocument);
                pagesCount = this.ProviderPaginator.GetPagesCount(htmlDocument);
            }
            catch (Exception ex)
            {
                //AppLog.LogMessage("providerbase_processurl_exception", BusquedaVehiculos.Infra.Serialization.Serializer.Serialize(ex));
                //AppLog.LogMessage("providerbase_processurl_exception", ex.ToMessageAndCompleteStackTrace());
            }
            return retorno;
        }
        #endregion

        #region Helpers
        private List<BusquedaResponseItemDTO> MapResponse(HtmlDocument htmlDocument)
        {
            var retorno = new List<BusquedaResponseItemDTO>();
            try
            {
                //Obtenemos los ítems devueltos por el provider
                var elementsResult = this.ProviderFormatter.GetItems(htmlDocument);

                //Recorremos cada ítem y le damos formato estándar
                foreach (var itemElementResult in elementsResult)
                {
                    var itemToAdd = new BusquedaResponseItemDTO()
                    {
                        Id = this.ProviderFormatter.GetId(itemElementResult),
                        Descripcion = this.ProviderFormatter.GetDescripcion(itemElementResult),
                        AnioModelo = this.ProviderFormatter.GetAnioModelo(itemElementResult),
                        Kilometros = this.ProviderFormatter.GetKilometros(itemElementResult),
                        Precio = this.ProviderFormatter.GetPrecio(itemElementResult),
                        Ubicacion = this.ProviderFormatter.GetUbicacion(itemElementResult),
                        UrlDetalle = this.ProviderFormatter.GetUrlDetalle(itemElementResult),
                        LinkImagen = this.ProviderFormatter.GetLinkImagen(itemElementResult),
                        Imagen = null //TODO: Determinar Byte[] a partir del link de la imagen
                    };
                    retorno.Add(itemToAdd);
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
