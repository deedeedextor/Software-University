using Microsoft.EntityFrameworkCore;
using PANDA.Models;

namespace PANDA.Data
{
    public class PANDAContext : DbContext
    {
        public PANDAContext()
        {
        }

        public PANDAContext(DbContextOptions<PANDAContext> options) : base()
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnestionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                   .HasKey(user => user.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
