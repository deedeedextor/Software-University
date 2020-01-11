namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        public RunesDbContext()
        {
        }

        public RunesDbContext(DbContextOptions<RunesDbContext> option)
            :base()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(user => user.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Track>()
                .Property(user => user.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Album>()
                .Property(user => user.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Album>()
                .HasMany(album => album.Tracks);
        }
    }
}
