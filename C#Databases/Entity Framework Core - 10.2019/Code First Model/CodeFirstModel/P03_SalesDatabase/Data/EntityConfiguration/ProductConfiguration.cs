using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                   .HasKey(k => k.ProductId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsUnicode()
                .HasDefaultValue("No description");

            builder
                .Property(p => p.Quantity);

            builder
                .Property(p => p.Price);

            builder
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(k => k.ProductId);
        }
    }
}
