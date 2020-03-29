using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            this.ToTable("TB_Provider");

            this.HasKey(x => x.CodProvider);

            this.Property(x => x.CodProvider)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescProvider)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.UrlBase)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.UrlCompleta)
                .IsMaxLength()
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.HasMany(x => x.Catalogos)
                .WithRequired(x => x.Provider)
                .HasForeignKey(x => x.CodProvider);

            this.HasMany(x => x.ComponetentesUrl)
                .WithRequired(x => x.Provider)
                .HasForeignKey(x => x.CodProvider);
        }
    }
}
