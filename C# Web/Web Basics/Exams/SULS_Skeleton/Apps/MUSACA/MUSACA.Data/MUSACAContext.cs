using Microsoft.EntityFrameworkCore;

namespace MUSACA.Data
{
    public class MUSACAContext : DbContext
    {
        public MUSACAContext()
        {
        }

        public MUSACAContext(DbContextOptions<MUSACAContext> options) : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnestionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
