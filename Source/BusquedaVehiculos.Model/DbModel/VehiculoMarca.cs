using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class VehiculoMarca
    {
        #region Constructores
        public VehiculoMarca()
        {
            this.SubMarcas = new List<VehiculoSubMarca>();
        }
        #endregion

        #region Atributos
        public String CodVehiculoMarca { get; set; }
        public String DescVehiculoMarca { get; set; }
        #endregion

        #region Referencias
        public virtual ICollection<VehiculoSubMarca> SubMarcas { get; set; }
        #endregion
    }
}
