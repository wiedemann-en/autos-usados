using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Busqueda
{
    public class BusquedaResponseItemDTO
    {
        #region Atributos
        public String Id { get; set; }
        public String Descripcion { get; set; }
        //public Int32 AnioModelo { get; set; }
        public String AnioModelo { get; set; }
        //public Decimal Kilometros { get; set; }
        public String Kilometros { get; set; }
        //public Decimal Precio { get; set; }
        public String Precio { get; set; }
        public String Ubicacion { get; set; }
        public String UrlDetalle { get; set; }
        public String LinkImagen { get; set; }
        public Byte[] Imagen { get; set; }
        #endregion
    }
}
