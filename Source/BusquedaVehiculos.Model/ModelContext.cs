using BusquedaVehiculos.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Model
{
    public class ModelContext : DbContext
    {
        #region Constructores y privados
        public ModelContext()
            : base("DbBusquedaVehiculos")
        {
        }
        #endregion

        #region DbSets
        public DbSet<Catalogo> CatalogoDataSet { get; set; }
        public DbSet<ComponenteUrl> ComposicionUrlDataSet { get; set; }
        public DbSet<Provider> ProviderDataSet { get; set; }
        public DbSet<ProviderCatalogo> ProviderCatalogoDataSet { get; set; }
        public DbSet<ProviderCatalogoItem> ProviderCatalogoItemDataSet { get; set; }
        public DbSet<ProviderCatalogoItemConv> ProviderCatalogoitemConvDataSet { get; set; }
        public DbSet<ProviderComponenteUrl> ProviderComposicionUrlDataSet { get; set; }
        public DbSet<VehiculoColor> VehiculoColorDataSet { get; set; }
        public DbSet<VehiculoCombustible> VehiculoCombustibleDataSet { get; set; }
        public DbSet<VehiculoDireccion> VehiculoDireccionDataSet { get; set; }
        public DbSet<VehiculoMarca> VehiculoMarcaDataSet { get; set; }
        public DbSet<VehiculoOrden> VehiculoOrdenDataSet { get; set; }
        public DbSet<VehiculoPuerta> VehiculoPuertaDataSet { get; set; }
        public DbSet<VehiculoProvincia> VehiculoProvinciaDataSet { get; set; }
        public DbSet<VehiculoSegmento> VehiculoSegmentoDataSet { get; set; }
        public DbSet<VehiculoSubMarca> VehiculoSubMarcaDataSet { get; set; }
        public DbSet<VehiculoTipo> VehiculoTipoDataSet { get; set; }
        public DbSet<VehiculoTraccion> VehiculoTraccionDataSet { get; set; }
        public DbSet<VehiculoTransmision> VehiculoTransmisionDataSet { get; set; }
        #endregion

        #region Model Creating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DbMapping.CatalogoMap());
            modelBuilder.Configurations.Add(new DbMapping.ComponenteUrlMap());
            modelBuilder.Configurations.Add(new DbMapping.ProviderMap());
            modelBuilder.Configurations.Add(new DbMapping.ProviderCatalogoMap());
            modelBuilder.Configurations.Add(new DbMapping.ProviderCatalogoItemMap());
            modelBuilder.Configurations.Add(new DbMapping.ProviderCatalogoItemConvMap());
            modelBuilder.Configurations.Add(new DbMapping.ProviderComponenteUrlMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoColorMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoCombustibleMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoDireccionMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoMarcaMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoOrdenMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoPuertaMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoProvinciaMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoSegmentoMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoSubMarcaMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoTipoMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoTraccionMap());
            modelBuilder.Configurations.Add(new DbMapping.VehiculoTransmisionMap());
        }
        #endregion
    }
}
