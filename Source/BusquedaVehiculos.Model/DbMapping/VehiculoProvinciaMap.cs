using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoProvinciaMap : EntityTypeConfiguration<VehiculoProvincia>
    {
        public VehiculoProvinciaMap()
        {
            this.ToTable("TB_VehiculoProvincia");

            this.HasKey(x => x.CodVehiculoProvincia);

            this.Property(x => x.CodVehiculoProvincia)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoProvincia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
