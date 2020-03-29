using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusquedaVehiculos.Providers.AlaMaula;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Tests.Builders;

namespace BusquedaVehiculos.Providers.Tests
{
    [TestClass]
    public class ProviderAlaMaulaTest
    {
        [TestMethod]
        public void PuedoArmarUrlDeConsulta()
        {
            var request = BusquedaRequestBuilder.BuilBusquedaRequestDTO();
            var urlComposer = new ProviderAlaMaulaUrlComposer();
            var result = urlComposer.GetUrlParsed(request, 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtengoListadoCompletoDeLaPagina()
        {
            var provider = new ProviderAlaMaulaSync();
            var result = provider.BuscarVehiculos(new BusquedaRequestDTO() { CodVehiculoTipo = "usado" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroMarca()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoCondicion = "usado";
            request.CodVehiculoMarca = "volkswagen";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroModelo()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoCondicion = "usado";
            request.CodVehiculoMarca = "volkswagen";
            request.CodVehiculoSubMarca = "gol";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroUbicacion()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoProvincia = "buenos-aires";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroAnio()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Anio.ValorDesde = 1990;
            request.Anio.ValorHasta = DateTime.Now.Year;
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroKilometraje()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Kilometraje.ValorDesde = 1000;
            request.Kilometraje.ValorHasta = 250000;
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroPrecio()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Precio.ValorDesde = 500;
            request.Precio.ValorHasta = 300000;
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroCommbustible()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoCondicion = "usado";
            request.CodVehiculoCombustible = "nafta";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroColor()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoCondicion = "usado";
            request.CodVehiculoColor = "gris";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoOrdenado()
        {
            var provider = new ProviderAlaMaulaSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Orden = "precio-ascendente";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }
    }
}
