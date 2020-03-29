using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoCombustibleMap : EntityTypeConfiguration<VehiculoCombustible>
    {
        public VehiculoCombustibleMap()
        {
            this.ToTable("TB_VehiculoCombustible");

            this.HasKey(x => x.CodVehiculoCombustible);

            this.Property(x => x.CodVehiculoCombustible)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoCombustible)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
