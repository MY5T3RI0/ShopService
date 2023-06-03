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
    public class PriceChangeConfiguration : IEntityTypeConfiguration<PriceChange>
    {
        public void Configure(EntityTypeBuilder<PriceChange> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.HasMany(c => c.Products)
                .WithMany(s => s.PriceChanges)
                .UsingEntity<ChangesDetails>(
                    j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(t => t.ChangesDetails)
                    .HasForeignKey(pt => pt.ProductId),
                    j => j
                        .HasOne(pt => pt.PriceChange)
                        .WithMany(p => p.ChangesDetails)
                        .HasForeignKey(pt => pt.PriceChangesId),
                    j =>
                    {
                        j.HasKey(t => new { t.PriceChangesId, t.ProductId });
                        j.ToTable("ChangeDetails");
                    });
        }
    }
}
