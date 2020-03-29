using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbModel
{
    public class Provider
    {
        #region Constructores
        public Provider()
        {
            this.Catalogos = new List<ProviderCatalogo>();
            this.ComponetentesUrl = new List<ProviderComponenteUrl>();
        }
        #endregion

        #region Atributos
        public String CodProvider { get; set; }
        public String DescProvider { get; set; }
        public String UrlBase { get; set; }
        public String UrlCompleta { get; set; }
        #endregion

        #region Referencias
        public virtual ICollection<ProviderCatalogo> Catalogos { get; set; }
        public virtual ICollection<ProviderComponenteUrl> ComponetentesUrl { get; set; }
        #endregion
    }
}
