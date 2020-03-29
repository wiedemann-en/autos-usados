using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaVehiculos.Contracts.Busqueda;
using System.Text.RegularExpressions;
using BusquedaVehiculos.Model;
using BusquedaVehiculos.Model.DbModel;
using BusquedaVehiculos.Contracts.Enums;
using BusquedaVehiculos.Interfaces.Providers;

namespace BusquedaVehiculos.Providers.Providers.Base
{
    internal abstract class ProviderBaseUrlComposer : IProviderUrlComposer
    {
        #region Atributos protected
        protected String CodProvider { get; set; }
        protected String UrlBuild { get; set; }
        #endregion

        #region IProviderUrlComposer
        public Uri GetUrlParsed(BusquedaRequestDTO request, int? page = null)
        {
            Uri retorno = null;
            try
            {
                using (var dbContext = new ModelContext())
                {
                    var provider = dbContext.ProviderDataSet.Single(x => x.CodProvider == this.CodProvider);
                    this.UrlBuild = provider.UrlCompleta;

                    //Filtro por tipo
                    if (!String.IsNullOrEmpty(request.CodVehiculoTipo))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroTipo, enCatalogo.Tipo, request.CodVehiculoTipo);

                    //Filtro por marca
                    if (!String.IsNullOrEmpty(request.CodVehiculoMarca))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroMarca, enCatalogo.Marca, request.CodVehiculoMarca);

                    //Filtro por modelo
                    if (!String.IsNullOrEmpty(request.CodVehiculoSubMarca))
                    {
                        var codModelo = String.Format("{0}@{1}", request.CodVehiculoMarca, request.CodVehiculoSubMarca);
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroModelo, enCatalogo.Modelo, codModelo);
                    }

                    //Filtro por provincia
                    if (!String.IsNullOrEmpty(request.CodVehiculoProvincia))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroUbicacion, enCatalogo.Provincia, request.CodVehiculoProvincia);

                    //Filtro por segmento
                    if (!String.IsNullOrEmpty(request.CodVehiculoSegmento))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroSegmento, enCatalogo.Segmento, request.CodVehiculoSegmento);

                    //Filtro por combustible
                    if (!String.IsNullOrEmpty(request.CodVehiculoCombustible))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroCombustible, enCatalogo.Combustible, request.CodVehiculoCombustible);

                    //Filtro por dirección
                    if (!String.IsNullOrEmpty(request.CodVehiculoDireccion))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroDireccion, enCatalogo.Direccion, request.CodVehiculoDireccion);

                    //Filtro por transmisión
                    if (!String.IsNullOrEmpty(request.CodVehiculoTransmision))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroTransmision, enCatalogo.Transmision, request.CodVehiculoTransmision);

                    //Filtro por tracción
                    if (!String.IsNullOrEmpty(request.CodVehiculoTraccion))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroTraccion, enCatalogo.Traccion, request.CodVehiculoTraccion);

                    //Filtro por color
                    if (!String.IsNullOrEmpty(request.CodVehiculoColor))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroColor, enCatalogo.Color, request.CodVehiculoColor);

                    //Filtro por puertas
                    if (!String.IsNullOrEmpty(request.CodVehiculoPuerta))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroPuertas, enCatalogo.Puertas, request.CodVehiculoPuerta);

                    //Filtro por condicion
                    if (!String.IsNullOrEmpty(request.CodVehiculoCondicion))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.FiltroCondicion, enCatalogo.Condicion, request.CodVehiculoCondicion);

                    //Filtro por año
                    if (request.Anio != null && this.CodProvider != enProvider.AutoFoco)
                        this.UrlBuild = this.TratarUrlRango(provider, this.UrlBuild, enComponenteUrl.FiltroAnio, request.Anio);
                    else if (request.Anio != null && this.CodProvider == enProvider.AutoFoco)
                    {
                        //TODO: Autofoco tiene implementacion rara para años
                        //&type_autos_year=2005&type_autos_year=2006&type_autos_year=2007&type_autos_year=2008&
                        var filtroAnio = new StringBuilder();
                        for (long iPos = request.Anio.ValorDesde; iPos <= request.Anio.ValorHasta; iPos++)
                            filtroAnio.Append(String.Format("&type_autos_year={0}", iPos));

                        if (filtroAnio.Length > 0)
                            this.UrlBuild = this.UrlBuild.Replace(String.Format("[{0}]", enComponenteUrl.FiltroAnio), filtroAnio.ToString());
                    }

                    //Filtro por kilometraje
                    if (request.Kilometraje != null)
                        this.UrlBuild = this.TratarUrlRango(provider, this.UrlBuild, enComponenteUrl.FiltroKilometros, request.Kilometraje);

                    //Filtro por precio
                    if (request.Precio != null)
                        this.UrlBuild = this.TratarUrlRango(provider, this.UrlBuild, enComponenteUrl.FiltroPrecio, request.Precio);

                    //Orden
                    if (!String.IsNullOrEmpty(request.Orden))
                        this.UrlBuild = this.TratarUrl(dbContext, provider, this.UrlBuild, enComponenteUrl.Orden, enCatalogo.Orden, request.Orden);

                    //Aplicamos el paginado en cada provider
                    var componenteUrlPage = provider.ComponetentesUrl.SingleOrDefault(x => x.CodComponente == enComponenteUrl.Pagina);
                    if (componenteUrlPage != null)
                    {
                        var pageCalculated = this.ParsePageProvider(page.GetValueOrDefault(1));
                        var componentePageSplit = componenteUrlPage.Expresion.Split('@');
                        for (int iPos = 0; iPos < componentePageSplit.Length; iPos++)
                        {
                            var replaceWith = componentePageSplit[iPos].Replace("[Value]", pageCalculated.ToString());

                            //Reemplazamos el valor en la cadena
                            if (!String.IsNullOrEmpty(replaceWith))
                            {
                                var indexToRemove = this.UrlBuild.IndexOf(String.Format("[{0}]", enComponenteUrl.Pagina));
                                this.UrlBuild = this.UrlBuild.Remove(indexToRemove, String.Format("[{0}]", enComponenteUrl.Pagina).Length);
                                this.UrlBuild = this.UrlBuild.Insert(indexToRemove, replaceWith);
                            }
                        }
                    }

                    //Ejecutamos lógica específica de cada provider
                    this.TratamientoUrlProvider();

                    //Eliminamos de la url los componentes que no se aplicaron
                    var componentes = enComponenteUrl.GetList();
                    foreach (var itemComponente in componentes)
                    {
                        this.UrlBuild = this.UrlBuild.Replace(String.Format("[{0}]", itemComponente), String.Empty);
                    }

                    //Eliminamos caracteres adicionales
                    var normalizar = new List<String>() { "&&", "~~", "//", "--", "__" };
                    foreach (var item in normalizar)
                    {
                        while (this.UrlBuild.Contains(item))
                            this.UrlBuild = this.UrlBuild.Replace(item, item[0].ToString());
                    }

                    //Verificamos el formato del protocolo
                    if ((!this.UrlBuild.StartsWith("http://")) && (!this.UrlBuild.StartsWith("https://")))
                    {
                        if (this.UrlBuild.StartsWith("http:/"))
                            this.UrlBuild = this.UrlBuild.Replace("http:/", "http://");
                        else if (this.UrlBuild.StartsWith("https:/"))
                            this.UrlBuild = this.UrlBuild.Replace("https:/", "https://");
                    }
                    if (this.UrlBuild.StartsWith("https://."))
                    {
                        this.UrlBuild = this.UrlBuild.Replace("https://.", "https://www.");
                    }

                    if (this.UrlBuild.Contains("/~"))
                        this.UrlBuild = this.UrlBuild.Replace("/~", "/");
                    if (this.UrlBuild.Contains("~/"))
                        this.UrlBuild = this.UrlBuild.Replace("~/", "/");
                    if (this.UrlBuild.Contains("-/") && (this.CodProvider != enProvider.AutoFoco))
                        this.UrlBuild = this.UrlBuild.Replace("-/", "/");

                    //Verificacion autofoco
                    if (this.UrlBuild.Contains("/?"))
                        this.UrlBuild = this.UrlBuild.Replace("/?", "?");

                    //Verificamos que no quede ultimo caracter
                    if (this.UrlBuild.EndsWith("&"))
                        this.UrlBuild = this.UrlBuild.Substring(0, this.UrlBuild.Length - 1);

                    //Asignamos el resultado
                    retorno = new Uri(this.UrlBuild);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
        #endregion

        #region Métodos virtuals
        protected virtual void TratamientoUrlProvider() { }
        protected virtual int ParsePageProvider(int page) { return page; }
        #endregion

        #region Helpers
        private String TratarUrl(ModelContext dbContext,
            Provider provider,
            String urlBuild,
            String codComponente,
            String codCatalogo,
            String codFiltro)
        {
            var retorno = urlBuild;

            var componenteUrl = provider.ComponetentesUrl.SingleOrDefault(x => x.CodComponente == codComponente);
            if (componenteUrl == null)
                return retorno;

            var catalogo = provider.Catalogos.SingleOrDefault(x => x.CodCatalogo == codCatalogo);
            if (catalogo == null)
                return retorno;

            var itemsConv = dbContext.ProviderCatalogoitemConvDataSet
                .Where(x => x.CodProvider == provider.CodProvider && x.CodCatalogo == codCatalogo && x.CodItemConv == codFiltro).ToList();
            if (itemsConv.Count == 0)
                return retorno;

            var codItemProvider = itemsConv.First().Item.CodItemProvider;
            if (codItemProvider.Split('@').Length == 2)
                codItemProvider = codItemProvider.Split('@')[1];
            var descItemProvider = this.LimpiarCadena(itemsConv.First().Item.DescItemProvider);

            var componenteSplit = componenteUrl.Expresion.Split('@');
            for (int iPos = 0; iPos < componenteSplit.Length; iPos++)
            {
                var replaceWith = string.Empty;
                if (componenteSplit[iPos].Contains("[Value]"))
                {
                    replaceWith = componenteSplit[iPos].Replace("[Value]", codItemProvider);
                }
                else if (componenteSplit[iPos].Contains("[Desc]"))
                {
                    replaceWith = componenteSplit[iPos].Replace("[Desc]", descItemProvider);
                }
                else
                {
                    replaceWith = componenteSplit[iPos];
                }

                //Reemplazamos el valor en la cadena
                if (!String.IsNullOrEmpty(replaceWith))
                {
                    //Validacion autofoco segmento
                    if (this.CodProvider == enProvider.AutoFoco && codComponente == enComponenteUrl.FiltroSegmento)
                    {
                        var indexToRemove = retorno.IndexOf(String.Format("-[{0}]", codComponente));
                        retorno = retorno.Remove(indexToRemove, String.Format("-[{0}]", codComponente).Length);
                        retorno = retorno.Insert(indexToRemove, replaceWith);
                    }
                    else
                    {
                        var indexToRemove = retorno.IndexOf(String.Format("[{0}]", codComponente));
                        retorno = retorno.Remove(indexToRemove, String.Format("[{0}]", codComponente).Length);
                        retorno = retorno.Insert(indexToRemove, replaceWith);
                    }
                }
            }
            return retorno;
        }

        private String TratarUrlRango(Provider provider,
            String urlBuild,
            String codComponente,
            BusquedaRequestRangeDTO busquedaRango)
        {
            var retorno = urlBuild;
            var componenteUrl = provider.ComponetentesUrl.SingleOrDefault(x => x.CodComponente == codComponente);
            if (componenteUrl != null)
            {
                var expresion = componenteUrl.Expresion;
                expresion = expresion.Replace("[ValueDesde]", busquedaRango.ValorDesde.ToString());
                expresion = expresion.Replace("[ValueHasta]", busquedaRango.ValorHasta.ToString());
                retorno = urlBuild.Replace(String.Format("[{0}]", codComponente), expresion);
            }
            return retorno;
        }

        private String LimpiarCadena(String input, String separador = "-")
        {
            var retorno = input.ToLower().Trim().Replace(" ", separador);
            var a = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            var e = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            var i = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            var o = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            var u = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            var n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            retorno = a.Replace(retorno, "a");
            retorno = e.Replace(retorno, "e");
            retorno = i.Replace(retorno, "i");
            retorno = o.Replace(retorno, "o");
            retorno = u.Replace(retorno, "u");
            retorno = n.Replace(retorno, "n");
            return retorno;
        }
        #endregion
    }
}
