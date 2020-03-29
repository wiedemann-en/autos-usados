namespace BusquedaVehiculos.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Catalogo",
                c => new
                    {
                        CodCatalogo = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescCatalogo = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.CodCatalogo);
            
            CreateTable(
                "dbo.TB_ComponenteUrl",
                c => new
                    {
                        CodComponente = c.String(nullable: false, maxLength: 64, unicode: false),
                        RequiereCatalogo = c.Boolean(nullable: false),
                        CodCatalogo = c.String(maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.CodComponente)
                .ForeignKey("dbo.TB_Catalogo", t => t.CodCatalogo)
                .Index(t => t.CodCatalogo);
            
            CreateTable(
                "dbo.TB_ProviderCatalogo",
                c => new
                    {
                        CodProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodCatalogo = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodProvider, t.CodCatalogo })
                .ForeignKey("dbo.TB_Catalogo", t => t.CodCatalogo, cascadeDelete: true)
                .ForeignKey("dbo.TB_Provider", t => t.CodProvider, cascadeDelete: true)
                .Index(t => t.CodProvider)
                .Index(t => t.CodCatalogo);
            
            CreateTable(
                "dbo.TB_ProviderCatalogoItem",
                c => new
                    {
                        CodProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodCatalogo = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodItemProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescItemProvider = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodProvider, t.CodCatalogo, t.CodItemProvider })
                .ForeignKey("dbo.TB_ProviderCatalogo", t => new { t.CodProvider, t.CodCatalogo }, cascadeDelete: true)
                .Index(t => new { t.CodProvider, t.CodCatalogo });
            
            CreateTable(
                "dbo.TB_ProviderCatalogoItemConv",
                c => new
                    {
                        CodProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodCatalogo = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodItemProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodItemConv = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodProvider, t.CodCatalogo, t.CodItemProvider, t.CodItemConv })
                .ForeignKey("dbo.TB_ProviderCatalogoItem", t => new { t.CodProvider, t.CodCatalogo, t.CodItemProvider }, cascadeDelete: true)
                .Index(t => new { t.CodProvider, t.CodCatalogo, t.CodItemProvider });
            
            CreateTable(
                "dbo.TB_Provider",
                c => new
                    {
                        CodProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescProvider = c.String(nullable: false, maxLength: 128, unicode: false),
                        UrlBase = c.String(nullable: false, maxLength: 255, unicode: false),
                        UrlCompleta = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CodProvider);
            
            CreateTable(
                "dbo.TB_ProviderComponenteUrl",
                c => new
                    {
                        CodProvider = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodComponente = c.String(nullable: false, maxLength: 64, unicode: false),
                        Expresion = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodProvider, t.CodComponente })
                .ForeignKey("dbo.TB_ComponenteUrl", t => t.CodComponente, cascadeDelete: true)
                .ForeignKey("dbo.TB_Provider", t => t.CodProvider, cascadeDelete: true)
                .Index(t => t.CodProvider)
                .Index(t => t.CodComponente);
            
            CreateTable(
                "dbo.TB_VehiculoColor",
                c => new
                    {
                        CodVehiculoColor = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoColor = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoColor);
            
            CreateTable(
                "dbo.TB_VehiculoCombustible",
                c => new
                    {
                        CodVehiculoCombustible = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoCombustible = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoCombustible);
            
            CreateTable(
                "dbo.TB_VehiculoDireccion",
                c => new
                    {
                        CodVehiculoDireccion = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoDireccion = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoDireccion);
            
            CreateTable(
                "dbo.TB_VehiculoMarca",
                c => new
                    {
                        CodVehiculoMarca = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoMarca = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoMarca);
            
            CreateTable(
                "dbo.TB_VehiculoSubMarca",
                c => new
                    {
                        CodVehiculoMarca = c.String(nullable: false, maxLength: 64, unicode: false),
                        CodVehiculoSubMarca = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoSubMarca = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodVehiculoMarca, t.CodVehiculoSubMarca })
                .ForeignKey("dbo.TB_VehiculoMarca", t => t.CodVehiculoMarca, cascadeDelete: true)
                .Index(t => t.CodVehiculoMarca);
            
            CreateTable(
                "dbo.TB_VehiculoOrden",
                c => new
                    {
                        CodVehiculoOrden = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoOrden = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoOrden);
            
            CreateTable(
                "dbo.TB_VehiculoProvincia",
                c => new
                    {
                        CodVehiculoProvincia = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoProvincia = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoProvincia);
            
            CreateTable(
                "dbo.TB_VehiculoPuerta",
                c => new
                    {
                        CodVehiculoPuerta = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoPuerta = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoPuerta);
            
            CreateTable(
                "dbo.TB_VehiculoSegmento",
                c => new
                    {
                        CodVehiculoSegmento = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoSegmento = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoSegmento);
            
            CreateTable(
                "dbo.TB_VehiculoTipo",
                c => new
                    {
                        CodVehiculoTipo = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoTipo = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoTipo);
            
            CreateTable(
                "dbo.TB_VehiculoTraccion",
                c => new
                    {
                        CodVehiculoTraccion = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoTraccion = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoTraccion);
            
            CreateTable(
                "dbo.TB_VehiculoTransmision",
                c => new
                    {
                        CodVehiculoTransmision = c.String(nullable: false, maxLength: 64, unicode: false),
                        DescVehiculoTransmision = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodVehiculoTransmision);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_VehiculoSubMarca", "CodVehiculoMarca", "dbo.TB_VehiculoMarca");
            DropForeignKey("dbo.TB_ProviderCatalogo", "CodProvider", "dbo.TB_Provider");
            DropForeignKey("dbo.TB_ProviderComponenteUrl", "CodProvider", "dbo.TB_Provider");
            DropForeignKey("dbo.TB_ProviderComponenteUrl", "CodComponente", "dbo.TB_ComponenteUrl");
            DropForeignKey("dbo.TB_ProviderCatalogoItem", new[] { "CodProvider", "CodCatalogo" }, "dbo.TB_ProviderCatalogo");
            DropForeignKey("dbo.TB_ProviderCatalogoItemConv", new[] { "CodProvider", "CodCatalogo", "CodItemProvider" }, "dbo.TB_ProviderCatalogoItem");
            DropForeignKey("dbo.TB_ProviderCatalogo", "CodCatalogo", "dbo.TB_Catalogo");
            DropForeignKey("dbo.TB_ComponenteUrl", "CodCatalogo", "dbo.TB_Catalogo");
            DropIndex("dbo.TB_VehiculoSubMarca", new[] { "CodVehiculoMarca" });
            DropIndex("dbo.TB_ProviderComponenteUrl", new[] { "CodComponente" });
            DropIndex("dbo.TB_ProviderComponenteUrl", new[] { "CodProvider" });
            DropIndex("dbo.TB_ProviderCatalogoItemConv", new[] { "CodProvider", "CodCatalogo", "CodItemProvider" });
            DropIndex("dbo.TB_ProviderCatalogoItem", new[] { "CodProvider", "CodCatalogo" });
            DropIndex("dbo.TB_ProviderCatalogo", new[] { "CodCatalogo" });
            DropIndex("dbo.TB_ProviderCatalogo", new[] { "CodProvider" });
            DropIndex("dbo.TB_ComponenteUrl", new[] { "CodCatalogo" });
            DropTable("dbo.TB_VehiculoTransmision");
            DropTable("dbo.TB_VehiculoTraccion");
            DropTable("dbo.TB_VehiculoTipo");
            DropTable("dbo.TB_VehiculoSegmento");
            DropTable("dbo.TB_VehiculoPuerta");
            DropTable("dbo.TB_VehiculoProvincia");
            DropTable("dbo.TB_VehiculoOrden");
            DropTable("dbo.TB_VehiculoSubMarca");
            DropTable("dbo.TB_VehiculoMarca");
            DropTable("dbo.TB_VehiculoDireccion");
            DropTable("dbo.TB_VehiculoCombustible");
            DropTable("dbo.TB_VehiculoColor");
            DropTable("dbo.TB_ProviderComponenteUrl");
            DropTable("dbo.TB_Provider");
            DropTable("dbo.TB_ProviderCatalogoItemConv");
            DropTable("dbo.TB_ProviderCatalogoItem");
            DropTable("dbo.TB_ProviderCatalogo");
            DropTable("dbo.TB_ComponenteUrl");
            DropTable("dbo.TB_Catalogo");
        }
    }
}
