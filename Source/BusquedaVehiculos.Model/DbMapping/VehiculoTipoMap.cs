using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoTipoMap : EntityTypeConfiguration<VehiculoTipo>
    {
        public VehiculoTipoMap()
        {
            this.ToTable("TB_VehiculoTipo");

            this.HasKey(x => x.CodVehiculoTipo);

            this.Property(x => x.CodVehiculoTipo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoTipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
