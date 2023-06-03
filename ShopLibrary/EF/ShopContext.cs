using Microsoft.EntityFrameworkCore;
using ShopDAL.EntityConfigurations;
using ShopDAL.Models;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL.EF
{
    public class ShopContext : DbContext, IShopContext
    {
        //public ShopContext() { }
        public ShopContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new PriceChangeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public string GetTableName(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Model.FindEntityType(type).GetTableName();
        }

        public Task<int> SavaChangesAsync(CancellationToken cancellationToken) =>
            SavaChangesAsync(cancellationToken);

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<PriceChange> PriceChanges { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<DeliveryInfo> DeliveryInfos { get; set; }
        public virtual DbSet<ChangesDetails> ChangesDetails { get; set; }
        public virtual DbSet<StoreProducts> StoreProducts { get; set; }
        public virtual DbSet<ProductsInStore> ProductsInStore { get; set; }

    }
}