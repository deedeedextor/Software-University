using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    internal class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder
                   .HasKey(k => k.VisitationId);

            builder
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(k => k.PatientId);
        }
    }
}
