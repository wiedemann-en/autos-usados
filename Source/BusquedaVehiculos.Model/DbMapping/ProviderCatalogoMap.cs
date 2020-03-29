using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class ProviderCatalogoMap : EntityTypeConfiguration<ProviderCatalogo>
    {
        public ProviderCatalogoMap()
        {
            this.ToTable("TB_ProviderCatalogo");

            this.HasKey(x => new { x.CodProvider, x.CodCatalogo });

            this.Property(x => x.CodProvider)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.CodCatalogo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasRequired(x => x.Provider)
                .WithMany(x => x.Catalogos)
                .HasForeignKey(x => x.CodProvider);

            this.HasRequired(x => x.Catalogo)
                .WithMany()
                .HasForeignKey(x => x.CodCatalogo);

            this.HasMany(x => x.Items)
                .WithRequired(x => x.ProviderCatalogo)
                .HasForeignKey(x => new { x.CodProvider, x.CodCatalogo });
        }
    }
}
