using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class ProviderCatalogoItem
    {
        #region Constructores
        public ProviderCatalogoItem()
        {
            this.ItemsConv = new List<ProviderCatalogoItemConv>();
        }
        #endregion

        #region Atributos
        public String CodProvider { get; set; }
        public String CodCatalogo { get; set; }
        public String CodItemProvider { get; set; }
        public String DescItemProvider { get; set; }
        #endregion

        #region Referencias
        public virtual ProviderCatalogo ProviderCatalogo { get; set; }
        public virtual ICollection<ProviderCatalogoItemConv> ItemsConv { get; set; }
        #endregion
    }
}
