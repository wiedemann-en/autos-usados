using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Tests.Builders
{
    internal static class BusquedaRequestBuilder
    {
        public static BusquedaRequestDTO BuilBusquedaRequestDTO()
        {
            var retorno = new BusquedaRequestDTO();
            retorno.CodVehiculoTipo = "usado";
            retorno.CodVehiculoMarca = "volkswagen";
            retorno.CodVehiculoSubMarca = "gol";
            retorno.CodVehiculoProvincia = "buenos-aires";
            retorno.CodVehiculoSegmento = "hatchback";
            retorno.CodVehiculoCombustible = "nafta";
            retorno.CodVehiculoDireccion = "hidraulica"; //asistida
            retorno.CodVehiculoTransmision = "manual";
            retorno.CodVehiculoTraccion = "4x2";
            retorno.CodVehiculoColor = "gris";
            retorno.CodVehiculoPuerta = "3-puertas";
            retorno.CodVehiculoCondicion = "usado";
            retorno.Anio.ValorDesde = 1990;
            retorno.Anio.ValorHasta = DateTime.Now.Year;
            retorno.Kilometraje.ValorDesde = 1000;
            retorno.Kilometraje.ValorHasta = 250000;
            retorno.Precio.ValorDesde = 500;
            retorno.Precio.ValorHasta = 300000;
            retorno.Orden = "kilometraje-ascendenete";
            return retorno;
        }
    }
}
