﻿namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                 .HasMany(c => c.Pets)
                 .WithOne(p => p.Category)
                 .HasForeignKey(k => k.CategoryId)
                 .OnDelete(DeleteBehavior.Cascade);

            category
                .HasMany(c => c.Food)
                .WithOne(f => f.Category)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            category
                .HasMany(c => c.Toys)
                .WithOne(t => t.Category)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
