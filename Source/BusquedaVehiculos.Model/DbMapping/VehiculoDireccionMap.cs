using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoDireccionMap : EntityTypeConfiguration<VehiculoDireccion>
    {
        public VehiculoDireccionMap()
        {
            this.ToTable("TB_VehiculoDireccion");

            this.HasKey(x => x.CodVehiculoDireccion);

            this.Property(x => x.CodVehiculoDireccion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoDireccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
