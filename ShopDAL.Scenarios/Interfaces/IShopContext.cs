using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Interfaces
{
    public interface IShopContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Delivery> Deliveries { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<PriceChange> PriceChanges { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Purchase> Purchases { get; set; }
        DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<DeliveryInfo> DeliveryInfos { get; set; }
        DbSet<ChangesDetails> ChangesDetails { get; set; }
        DbSet<StoreProducts> StoreProducts { get; set; }
        DbSet<ProductsInStore> ProductsInStore { get; set; }

        Task<int> SavaChangesAsync(CancellationToken cancellationToken);
    } 
}