﻿namespace PerStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder
                .HasKey(to => new { to.ToyId, to.OrderId });

            toyOrder
                .HasOne(to => to.Toy)
                .WithMany(o => o.Orders)
                .HasForeignKey(to => to.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            toyOrder
                .HasOne(to => to.Order)
                .WithMany(o => o.Toys)
                .HasForeignKey(to => to.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
