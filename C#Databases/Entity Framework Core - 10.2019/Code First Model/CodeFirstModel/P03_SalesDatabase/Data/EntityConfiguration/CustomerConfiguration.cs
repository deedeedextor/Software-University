using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                   .HasKey(k => k.CustomerId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder
                .Property(p => p.Email)
                .HasMaxLength(80);

            builder
                .Property(p => p.CreditCardNumber);

            builder
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(k => k.CustomerId);
        }
    }
}
