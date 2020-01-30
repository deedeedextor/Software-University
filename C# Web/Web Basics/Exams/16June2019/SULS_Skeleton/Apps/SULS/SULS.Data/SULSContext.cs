namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
        public SULSContext()
        {
        }

        public SULSContext(DbContextOptions<SULSContext> options)
            :base()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnestionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}