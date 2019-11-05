namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationOnPlayerStatistic(modelBuilder);
            ConfigurationOnTown(modelBuilder);
            ConfigurationOnTeam(modelBuilder);
            ConfigurationOnGame(modelBuilder);
        }

        private void ConfigurationOnGame(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()
                .HasKey(k => k.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(ht => ht.HomeTeam)
                .WithMany(hg => hg.HomeGames)
                .HasForeignKey(k => k.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Game>()
                .HasOne(ht => ht.AwayTeam)
                .WithMany(hg => hg.AwayGames)
                .HasForeignKey(k => k.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigurationOnTeam(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Team>()
                .HasKey(k => k.TeamId);

            modelBuilder
                .Entity<Team>()
                .HasOne(pk => pk.PrimaryKitColor)
                .WithMany(pt => pt.PrimaryKitTeams)
                .HasForeignKey(k => k.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Team>()
                .HasOne(pk => pk.SecondaryKitColor)
                .WithMany(pt => pt.SecondaryKitTeams)
                .HasForeignKey(k => k.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigurationOnTown(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Town>()
                .HasKey(k => k.TownId);
        
            modelBuilder
                .Entity<Town>()
                .HasOne(c => c.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(k => k.CountryId);
        }

        private void ConfigurationOnPlayerStatistic(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PlayerStatistic>()
                .HasKey(k => new { k.GameId, k.PlayerId });
        }
    }
}
