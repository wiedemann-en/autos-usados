using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BusquedaVehiculos.Providers.DeMotores;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Tests.Builders;

namespace BusquedaVehiculos.Providers.Tests
{
    [TestClass]
    public class ProviderDeMotoresTest
    {
        [TestMethod]
        public void PuedoArmarUrlDeConsulta()
        {
            var request = BusquedaRequestBuilder.BuilBusquedaRequestDTO();
            var urlComposer = new ProviderDeMotoresUrlComposer();
            var result = urlComposer.GetUrlParsed(request, 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtengoListadoCompletoDeLaPagina()
        {
            var provider = new ProviderDeMotoresSync();
            var result = provider.BuscarVehiculos(new BusquedaRequestDTO() { CodVehiculoTipo = "usado" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroMarca()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoMarca = "volkswagen";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroModelo()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoMarca = "volkswagen";
            request.CodVehiculoSubMarca = "gol";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroUbicacion()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoProvincia = "cordoba";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroAnio()
        {
            var provider = new ProviderDeMotoresSync();
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
            var provider = new ProviderDeMotoresSync();
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
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Precio.ValorDesde = 500;
            request.Precio.ValorHasta = 300000;
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroDireccion()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoDireccion = "hidraulica";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroCommbustible()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoCombustible = "nafta";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroTransmision()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoTransmision = "manual";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroSegmento()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoSegmento = "hatchback";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroPuertas()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoPuerta = "3-puertas";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroColor()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoColor = "gris";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoOrdenado()
        {
            var provider = new ProviderDeMotoresSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Orden = "kilometraje-ascendenete";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }
    }
}
