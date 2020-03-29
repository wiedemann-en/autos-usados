using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class ComponenteUrlMap : EntityTypeConfiguration<ComponenteUrl>
    {
        public ComponenteUrlMap()
        {
            this.ToTable("TB_ComponenteUrl");

            this.HasKey(x => x.CodComponente);

            this.Property(x => x.CodComponente)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.CodCatalogo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsOptional()
                .IsVariableLength();

            this.Property(x => x.RequiereCatalogo)
                .IsRequired();

            this.HasOptional(x => x.Catalogo)
                .WithMany()
                .HasForeignKey(x => x.CodCatalogo);
        }
    }
}
