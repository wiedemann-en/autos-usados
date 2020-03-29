using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class VehiculoSubMarca
    {
        #region Atributos
        public String CodVehiculoSubMarca { get; set; }
        public String CodVehiculoMarca { get; set; }
        public String DescVehiculoSubMarca { get; set; }
        #endregion

        #region Referencias
        public virtual VehiculoMarca VehiculoMarca { get; set; }
        #endregion
    }
}
