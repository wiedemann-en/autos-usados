using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoOrdenMap : EntityTypeConfiguration<VehiculoOrden>
    {
        public VehiculoOrdenMap()
        {
            this.ToTable("TB_VehiculoOrden");

            this.HasKey(x => x.CodVehiculoOrden);

            this.Property(x => x.CodVehiculoOrden)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoOrden)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
