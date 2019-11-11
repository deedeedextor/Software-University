using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(k => k.DoctorId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            builder
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(p => p.Password)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            builder
                .HasMany(v => v.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(k => k.DoctorId);
        }
    }
}
