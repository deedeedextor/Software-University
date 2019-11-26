namespace PerStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> pet)
        {
            pet
                 .HasOne(p => p.Breed)
                 .WithMany(b => b.Pets)
                 .HasForeignKey(k => k.BreedId)
                 .OnDelete(DeleteBehavior.Restrict);

            pet
                .HasOne(p => p.Order)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
