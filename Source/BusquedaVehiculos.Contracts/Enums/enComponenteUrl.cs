using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Enums
{
    public static class enComponenteUrl
    {
        public static string FiltroTipo = "FILTRO_TIPO";
        public static string FiltroMarca = "FILTRO_MARCA";
        public static string FiltroModelo = "FILTRO_MODELO";
        public static string FiltroUbicacion = "FILTRO_UBICACION";
        public static string FiltroAnio = "FILTRO_ANIO";
        public static string FiltroKilometros = "FILTRO_KILOMETROS";
        public static string FiltroPrecio = "FILTRO_PRECIO";
        public static string FiltroDireccion = "FILTRO_DIRECCION";
        public static string FiltroCombustible = "FILTRO_COMBUSTIBLE";
        public static string FiltroTransmision = "FILTRO_TRANSMISION";
        public static string FiltroSegmento = "FILTRO_SEGMENTO";
        public static string FiltroPuertas = "FILTRO_PUERTAS";
        public static string FiltroTraccion = "FILTRO_TRACCION";
        public static string FiltroColor = "FILTRO_COLOR";
        public static string FiltroCondicion = "FILTRO_CONDICION";
        public static string Orden = "ORDEN";
        public static string Pagina = "PAGINA";

        #region Logic
        public static List<String> GetList()
        {
            var retorno = new List<String>();
            retorno.Add(enComponenteUrl.FiltroTipo);
            retorno.Add(enComponenteUrl.FiltroMarca);
            retorno.Add(enComponenteUrl.FiltroModelo);
            retorno.Add(enComponenteUrl.FiltroUbicacion);
            retorno.Add(enComponenteUrl.FiltroAnio);
            retorno.Add(enComponenteUrl.FiltroKilometros);
            retorno.Add(enComponenteUrl.FiltroPrecio);
            retorno.Add(enComponenteUrl.FiltroDireccion);
            retorno.Add(enComponenteUrl.FiltroCombustible);
            retorno.Add(enComponenteUrl.FiltroTransmision);
            retorno.Add(enComponenteUrl.FiltroSegmento);
            retorno.Add(enComponenteUrl.FiltroPuertas);
            retorno.Add(enComponenteUrl.FiltroTraccion);
            retorno.Add(enComponenteUrl.FiltroColor);
            retorno.Add(enComponenteUrl.FiltroCondicion);
            retorno.Add(enComponenteUrl.Orden);
            retorno.Add(enComponenteUrl.Pagina);
            return retorno;
        }
        #endregion
    }
}
