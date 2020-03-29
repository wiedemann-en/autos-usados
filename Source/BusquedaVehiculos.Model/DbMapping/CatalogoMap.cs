using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model.DbMapping
{
    class CatalogoMap : EntityTypeConfiguration<Catalogo>
    {
        public CatalogoMap()
        {
            this.ToTable("TB_Catalogo");

            this.HasKey(x => x.CodCatalogo);

            this.Property(x => x.CodCatalogo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();

            this.Property(x => x.DescCatalogo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
