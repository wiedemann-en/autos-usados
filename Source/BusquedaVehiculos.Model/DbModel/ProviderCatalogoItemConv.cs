using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class ProviderCatalogoItemConv
    {
        #region Atributos
        public String CodProvider { get; set; }
        public String CodCatalogo { get; set; }
        public String CodItemProvider { get; set; }
        public String CodItemConv { get; set; }
        #endregion

        #region Referencias
        public virtual ProviderCatalogoItem Item { get; set; }
        #endregion
    }
}
