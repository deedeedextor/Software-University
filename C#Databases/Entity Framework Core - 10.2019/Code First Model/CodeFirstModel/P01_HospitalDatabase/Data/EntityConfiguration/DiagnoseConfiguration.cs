using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    internal class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder
                   .HasKey(k => k.DiagnoseId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(k => k.PatientId);
        }
    }
}
