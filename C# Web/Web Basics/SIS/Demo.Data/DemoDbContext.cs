using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(user => user.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
