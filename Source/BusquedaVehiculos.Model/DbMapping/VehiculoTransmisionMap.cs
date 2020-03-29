using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoTransmisionMap : EntityTypeConfiguration<VehiculoTransmision>
    {
        public VehiculoTransmisionMap()
        {
            this.ToTable("TB_VehiculoTransmision");

            this.HasKey(x => x.CodVehiculoTransmision);

            this.Property(x => x.CodVehiculoTransmision)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoTransmision)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
