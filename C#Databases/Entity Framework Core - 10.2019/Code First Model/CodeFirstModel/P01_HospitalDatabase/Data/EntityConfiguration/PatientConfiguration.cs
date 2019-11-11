using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasKey(k => k.PatientId);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder
                .Property(p => p.Email)
                .HasMaxLength(80);

            builder
                .Property(p => p.HasInsurance);

            builder
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.VisitationId);

            builder
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.DiagnoseId);

            builder
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.PatientId);
        }
    }
}
