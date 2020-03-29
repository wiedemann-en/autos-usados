using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoSegmentoMap : EntityTypeConfiguration<VehiculoSegmento>
    {
        public VehiculoSegmentoMap()
        {
            this.ToTable("TB_VehiculoSegmento");

            this.HasKey(x => x.CodVehiculoSegmento);

            this.Property(x => x.CodVehiculoSegmento)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoSegmento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
