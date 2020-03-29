using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusquedaVehiculos.Providers.MercadoLibre;
using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Tests.Builders;

namespace BusquedaVehiculos.Providers.Tests
{
    [TestClass]
    public class ProviderMercadoLibreTest
    {
        [TestMethod]
        public void PuedoArmarUrlDeConsulta()
        {
            var request = BusquedaRequestBuilder.BuilBusquedaRequestDTO();
            var urlComposer = new ProviderMercadoLibreUrlComposer();
            var result = urlComposer.GetUrlParsed(request, 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtengoListadoCompletoDeLaPagina()
        {
            var provider = new ProviderMercadoLibreSync();
            var result = provider.BuscarVehiculos(new BusquedaRequestDTO() { CodVehiculoTipo = "usado" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroMarca()
        {
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Anio.ValorDesde = 1995;
            request.Anio.ValorHasta = DateTime.Now.Year;
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroKilometraje()
        {
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.CodVehiculoTransmision = "manual";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void ObtengoListadoConFiltroPuertas()
        {
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
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
            var provider = new ProviderMercadoLibreSync();
            var request = new BusquedaRequestDTO();
            request.CodVehiculoTipo = "usado";
            request.Orden = "precio-ascendente";
            var result = provider.BuscarVehiculos(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count > 0);
        }
    }
}
