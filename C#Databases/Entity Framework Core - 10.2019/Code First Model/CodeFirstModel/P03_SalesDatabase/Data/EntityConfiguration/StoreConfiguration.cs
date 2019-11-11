using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                   .HasKey(k => k.StoreId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode();

            builder
                .HasMany(s => s.Sales)
                .WithOne(st => st.Store)
                .HasForeignKey(k => k.StoreId);
        }
    }
}
