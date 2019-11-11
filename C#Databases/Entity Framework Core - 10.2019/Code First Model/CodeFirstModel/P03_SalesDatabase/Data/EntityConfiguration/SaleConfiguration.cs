using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                   .HasKey(k => k.SaleId);

            builder
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.ProductId);

            builder
                .HasOne(c => c.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.CustomerId);

            builder
                .HasOne(st => st.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.StoreId);
        }
    }
}
