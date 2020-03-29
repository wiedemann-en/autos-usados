using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class ProviderComponenteUrl
    {
        #region Atributos
        public String CodProvider { get; set; }
        public String CodComponente { get; set; }
        public String Expresion { get; set; }
        #endregion

        #region Referencias
        public virtual Provider Provider { get; set; }
        public virtual ComponenteUrl ComponenteUrl { get; set; }
        #endregion
    }
}
