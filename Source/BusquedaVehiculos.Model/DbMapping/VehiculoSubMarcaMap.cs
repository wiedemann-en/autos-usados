using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoSubMarcaMap : EntityTypeConfiguration<VehiculoSubMarca>
    {
        public VehiculoSubMarcaMap()
        {
            this.ToTable("TB_VehiculoSubMarca");

            this.HasKey(x => new { x.CodVehiculoMarca, x.CodVehiculoSubMarca });

            this.Property(x => x.CodVehiculoMarca)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.CodVehiculoSubMarca)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoSubMarca)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasRequired(x => x.VehiculoMarca)
                .WithMany(x => x.SubMarcas)
                .HasForeignKey(x => x.CodVehiculoMarca);
        }
    }
}
