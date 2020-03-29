using BusquedaVehiculos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusquedaVehiculos.Web.Services
{
    public static class SelectListProvider
    {
        #region Constructores
        static SelectListProvider()
        {
        }
        #endregion

        #region Initialize
        private static void Initialize()
        {
        }
        #endregion

        #region Interfaz pública
        public static List<SelectListItem> GetOptionsBoolean()
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem() { Value = true.ToString(), Text = "Si" });
            retorno.Add(new SelectListItem() { Value = false.ToString(), Text = "No" });
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoProvincia()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoProvinciaDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoProvincia, Text = x.DescVehiculoProvincia }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoMarca()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoMarcaDataSet.ToList();
                retorno = marcas.Select(x => 
                    new SelectListItem() { Value = x.CodVehiculoMarca, Text = x.DescVehiculoMarca }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoSubMarca(String codVehiculoMarca)
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var subMarcas = dbContext.VehiculoSubMarcaDataSet.Where(x => x.CodVehiculoMarca == codVehiculoMarca).ToList();
                retorno = subMarcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoSubMarca, Text = x.DescVehiculoSubMarca }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoColor()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoColorDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoColor, Text = x.DescVehiculoColor }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoCombustible()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoCombustibleDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoCombustible, Text = x.DescVehiculoCombustible }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoDireccion()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoDireccionDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoDireccion, Text = x.DescVehiculoDireccion }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoPuerta()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoPuertaDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoPuerta, Text = x.DescVehiculoPuerta }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoSegmento()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoSegmentoDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoSegmento, Text = x.DescVehiculoSegmento }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoTraccion()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoTraccionDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoTraccion, Text = x.DescVehiculoTraccion }).ToList();
            }
            return retorno;
        }
        public static List<SelectListItem> GetOptionsVehiculoTransmision()
        {
            var retorno = new List<SelectListItem>();
            using (var dbContext = new ModelContext())
            {
                var marcas = dbContext.VehiculoTransmisionDataSet.ToList();
                retorno = marcas.Select(x =>
                    new SelectListItem() { Value = x.CodVehiculoTransmision, Text = x.DescVehiculoTransmision }).ToList();
            }
            return retorno;
        }
        #endregion
    }
}