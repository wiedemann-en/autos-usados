using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaVehiculos.Web.Models.Busqueda
{
    public class BusquedaRequestVM
    {
        #region Constructores
        public BusquedaRequestVM()
        {
            this.Formulario = new BusquedaRequestDTO();
        }
        #endregion

        #region Atributos
        public BusquedaRequestDTO Formulario { get; set; }
        #endregion
    }
}