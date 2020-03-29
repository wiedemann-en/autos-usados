using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Busqueda
{
    public class BusquedaRequestDTO
    {
        #region Constructores
        public BusquedaRequestDTO()
        {
            //this.CodVehiculoTipo = new List<String>();
            //this.CodVehiculoMarca = new List<String>();
            //this.CodVehiculoSubMarca = new List<String>();
            //this.CodVehiculoProvincia = new List<String>();
            //this.CodVehiculoSegmento = new List<String>();
            //this.CodVehiculoCombustible = new List<String>();
            //this.CodVehiculoDireccion = new List<String>();
            //this.CodVehiculoTransmision = new List<String>();
            //this.CodVehiculoTraccion = new List<String>();
            //this.CodVehiculoColor = new List<String>();
            //this.CodVehiculoPuerta = new List<String>();
            //this.CodVehiculoCondicion = new List<String>();
            this.Anio = new BusquedaRequestRangeDTO(DateTime.Now.AddYears(-100).Year, DateTime.Now.Year);
            this.Kilometraje = new BusquedaRequestRangeDTO(0, 9999999);
            this.Precio = new BusquedaRequestRangeDTO(0, 9999999);
        }
        #endregion

        #region Atributos
        public String CodVehiculoTipo { get; set; }
        public String CodVehiculoMarca { get; set; }
        public String CodVehiculoSubMarca { get; set; }
        public String CodVehiculoProvincia { get; set; }
        public String CodVehiculoSegmento { get; set; }
        public String CodVehiculoCombustible { get; set; }
        public String CodVehiculoDireccion { get; set; }
        public String CodVehiculoTransmision { get; set; }
        public String CodVehiculoTraccion { get; set; }
        public String CodVehiculoColor { get; set; }
        public String CodVehiculoPuerta { get; set; }
        public String CodVehiculoCondicion { get; set; }
        public BusquedaRequestRangeDTO Anio { get; set; }
        public BusquedaRequestRangeDTO Kilometraje { get; set; }
        public BusquedaRequestRangeDTO Precio { get; set; }
        public String Orden { get; set; }
        #endregion
    }
}
