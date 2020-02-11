using Microsoft.EntityFrameworkCore;
using Torshia.Data;
using Torshia.Models;

namespace Totshia.Data
{
    public class TORSHIAContext : DbContext
    {
        public TORSHIAContext()
        {
        }

        public TORSHIAContext(DbContextOptions<TORSHIAContext> options) : base()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<TaskSector> TasksSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnestionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Reports)
                .WithOne(x => x.Reporter)
                .HasForeignKey(x => x.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Task>()
               .HasMany(x => x.Reports)
               .WithOne(x => x.Task)
               .HasForeignKey(x => x.TaskId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Task>()
               .HasMany(x => x.AffectedSectors)
               .WithOne(x => x.Task)
               .HasForeignKey(x => x.TaskId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
