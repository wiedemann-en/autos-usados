using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class ProviderCatalogoItemConvMap : EntityTypeConfiguration<ProviderCatalogoItemConv>
    {
        public ProviderCatalogoItemConvMap()
        {
            this.ToTable("TB_ProviderCatalogoItemConv");

            this.HasKey(x => new { x.CodProvider, x.CodCatalogo, x.CodItemProvider, x.CodItemConv });

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

            this.Property(x => x.CodItemConv)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasRequired(x => x.Item)
                .WithMany(x => x.ItemsConv)
                .HasForeignKey(x => new { x.CodProvider, x.CodCatalogo, x.CodItemProvider });
        }
    }
}
