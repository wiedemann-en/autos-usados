using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class ProviderCatalogo
    {
        #region Constructores
        public ProviderCatalogo()
        {
            this.Items = new List<ProviderCatalogoItem>();
        }
        #endregion

        #region Atributos
        public String CodProvider { get; set; }
        public String CodCatalogo { get; set; }
        #endregion

        #region Referencias
        public virtual Provider Provider { get; set; }
        public virtual Catalogo Catalogo { get; set; }
        public virtual ICollection<ProviderCatalogoItem> Items { get; set; }
        #endregion
    }
}
