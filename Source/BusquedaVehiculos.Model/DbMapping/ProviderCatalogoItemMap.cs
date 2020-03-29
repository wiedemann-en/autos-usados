using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class ProviderCatalogoItemMap : EntityTypeConfiguration<ProviderCatalogoItem>
    {
        public ProviderCatalogoItemMap()
        {
            this.ToTable("TB_ProviderCatalogoItem");

            this.HasKey(x => new { x.CodProvider, x.CodCatalogo, x.CodItemProvider });

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

            this.Property(x => x.CodItemProvider)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescItemProvider)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasRequired(x => x.ProviderCatalogo)
                .WithMany(x => x.Items)
                .HasForeignKey(x => new { x.CodProvider, x.CodCatalogo });

            this.HasMany(x => x.ItemsConv)
                .WithRequired(x => x.Item)
                .HasForeignKey(x => new { x.CodProvider, x.CodCatalogo, x.CodItemProvider });
        }
    }
}
