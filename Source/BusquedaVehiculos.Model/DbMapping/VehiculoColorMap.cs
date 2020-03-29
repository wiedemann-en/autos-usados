using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoColorMap : EntityTypeConfiguration<VehiculoColor>
    {
        public VehiculoColorMap()
        {
            this.ToTable("TB_VehiculoColor");

            this.HasKey(x => x.CodVehiculoColor);

            this.Property(x => x.CodVehiculoColor)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoColor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
