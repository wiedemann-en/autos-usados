using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoTraccionMap : EntityTypeConfiguration<VehiculoTraccion>
    {
        public VehiculoTraccionMap()
        {
            this.ToTable("TB_VehiculoTraccion");

            this.HasKey(x => x.CodVehiculoTraccion);

            this.Property(x => x.CodVehiculoTraccion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoTraccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
