using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class ComponenteUrl
    {
        #region Atributos
        public String CodComponente { get; set; }
        public Boolean RequiereCatalogo { get; set; }
        public String CodCatalogo { get; set; }
        #endregion

        #region Referencias
        public virtual Catalogo Catalogo { get; set; }
        #endregion
    }
}
