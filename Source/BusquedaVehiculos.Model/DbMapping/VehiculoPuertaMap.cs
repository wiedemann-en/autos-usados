using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoPuertaMap : EntityTypeConfiguration<VehiculoPuerta>
    {
        public VehiculoPuertaMap()
        {
            this.ToTable("TB_VehiculoPuerta");

            this.HasKey(x => x.CodVehiculoPuerta);

            this.Property(x => x.CodVehiculoPuerta)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoPuerta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
