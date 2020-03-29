using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class VehiculoMarcaMap : EntityTypeConfiguration<VehiculoMarca>
    {
        public VehiculoMarcaMap()
        {
            this.ToTable("TB_VehiculoMarca");

            this.HasKey(x => x.CodVehiculoMarca);

            this.Property(x => x.CodVehiculoMarca)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescVehiculoMarca)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasMany(x => x.SubMarcas)
                .WithRequired(x => x.VehiculoMarca)
                .HasForeignKey(x => x.CodVehiculoMarca);
        }
    }
}
