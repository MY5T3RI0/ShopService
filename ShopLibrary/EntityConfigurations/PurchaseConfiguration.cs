using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.EntityConfigurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.HasMany(c => c.Stores)
                .WithMany(s => s.Purchases)
                .UsingEntity<StoreProducts>(
                    j => j
                    .HasOne(pt => pt.Store)
                    .WithMany(t => t.StoreProducts)
                    .HasForeignKey(pt => pt.StoreId),
                    j => j
                        .HasOne(pt => pt.Purchase)
                        .WithMany(p => p.StoreProducts)
                        .HasForeignKey(pt => pt.PurchaseId),
                    j =>
                    {
                        j.HasKey(t => new { t.Id });
                        j.ToTable("StoreProducts");
                    });
        }
    }
}
