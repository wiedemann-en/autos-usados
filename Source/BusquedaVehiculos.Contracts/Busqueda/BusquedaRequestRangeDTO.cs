using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Busqueda
{
    public class BusquedaRequestRangeDTO
    {
        #region Constructores
        public BusquedaRequestRangeDTO()
            : this(0, 0)
        {
        }
        public BusquedaRequestRangeDTO(Int64 valorDesde, Int64 valorHasta)
        {
            this.ValorDesde = valorDesde;
            this.ValorHasta = valorHasta;
        }
        #endregion

        #region Atributos
        public Int64 ValorDesde { get; set; }
        public Int64 ValorHasta { get; set; }
        #endregion
    }
}
