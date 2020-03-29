using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Providers.Manager;
using BusquedaVehiculos.Providers.SignalR;
using BusquedaVehiculos.Web.Infra;
using BusquedaVehiculos.Web.Models.Busqueda;
using BusquedaVehiculos.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusquedaVehiculos.Web.Controllers
{
    public class BusquedaController : Controller
    {
        #region Actions
        [HttpGet]
        public ActionResult Index()
        {
            var model = new BusquedaRequestVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Resultado(BusquedaRequestVM rquest)
        {
            var model = new BusquedaResponseVM();

            //Disparamos importación async
            var buscador = new ProviderManagerSingalR(new BusquedaLongRunningTask());
            var job = BusquedaJobManager.CreateJob(rquest.Formulario, buscador);
            model.JobId = job.Id;

            ViewBag.DescripcionBusqueda = ArmarDescripcion(rquest);

            return View(model);
        }

        private String ArmarDescripcion(BusquedaRequestVM rquest)
        {
            var result = String.Empty;

            if (!String.IsNullOrWhiteSpace(rquest.Formulario.CodVehiculoMarca))
            {
                var optionsVehiculoMarca = SelectListProvider.GetOptionsVehiculoMarca();
                var DescMarca = optionsVehiculoMarca.SingleOrDefault(x => x.Value == rquest.Formulario.CodVehiculoMarca).Text;

                result = DescMarca;
            }
            if (!String.IsNullOrWhiteSpace(rquest.Formulario.CodVehiculoSubMarca))
            {
                var optionsVehiculoSubMarca = SelectListProvider.GetOptionsVehiculoSubMarca(rquest.Formulario.CodVehiculoMarca);
                var DescSubMarca = optionsVehiculoSubMarca.SingleOrDefault(x => x.Value == rquest.Formulario.CodVehiculoSubMarca).Text;

                result = result + ", " + DescSubMarca;
            }
            if (!String.IsNullOrWhiteSpace(rquest.Formulario.CodVehiculoProvincia))
            {
                var optionsVehiculoProvincia = SelectListProvider.GetOptionsVehiculoProvincia();
                var DescProvincia = optionsVehiculoProvincia.SingleOrDefault(x => x.Value == rquest.Formulario.CodVehiculoProvincia).Text;

                result = result + ", " + DescProvincia;
            }
            //var optionsVehiculoColor = SelectListProvider.GetOptionsVehiculoColor();
            //var optionsVehiculoCombustible = SelectListProvider.GetOptionsVehiculoCombustible();
            //var optionsVehiculoDireccion = SelectListProvider.GetOptionsVehiculoDireccion();
            //var optionsVehiculoPuerta = SelectListProvider.GetOptionsVehiculoPuerta();
            //var optionsVehiculoSegmento = SelectListProvider.GetOptionsVehiculoSegmento();
            //var optionsVehiculoTraccion = SelectListProvider.GetOptionsVehiculoTraccion();
            //var optionsVehiculoTransmision = SelectListProvider.GetOptionsVehiculoTransmision();

            return result;
        }
        #endregion

        #region Jsons
        public JsonResult GetVehiculoSubMarca(String codVehiculoMarca)
        {
            var optionsVehiculoSubMarca = SelectListProvider.GetOptionsVehiculoSubMarca(codVehiculoMarca);
            return Json(optionsVehiculoSubMarca);
        }
        public JsonResult GetProvidersDisponibles(BusquedaRequestDTO request)
        {
            var providerDisponible = new ProviderDisponible();
            var providers = providerDisponible.GetProvidersDisponibles(request);
            return Json(providers);
        }
        #endregion
    }
}