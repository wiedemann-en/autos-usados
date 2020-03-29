using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Busqueda
{
    public class BusquedaResponseDTO
    {
        #region Constructores
        public BusquedaResponseDTO()
        {
            this.Items = new List<BusquedaResponseItemDTO>();
        }
        #endregion

        #region Atributos públicos
        public String CodProvider { get; set; }
        public List<BusquedaResponseItemDTO> Items { get; set; }
        #endregion
    }
}
