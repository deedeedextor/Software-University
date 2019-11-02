namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

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
            ConfigurationOnProduct(modelBuilder);
            ConfigurationOnCustomer(modelBuilder);
            ConfigurationOnStore(modelBuilder);
            ConfigurationOnSale(modelBuilder);
        }

        private void ConfigurationOnSale(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(k => k.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.ProductId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(st => st.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(k => k.StoreId);
        }

        private void ConfigurationOnStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(k => k.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(st => st.Store)
                .HasForeignKey(k => k.StoreId);
        }

        private static void ConfigurationOnCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(k => k.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Email)
                .HasMaxLength(80);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.CreditCardNumber);

            modelBuilder
                .Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(k => k.CustomerId);
        }

        private static void ConfigurationOnProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(k => k.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsUnicode()
                .HasDefaultValue("No description");

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Quantity);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Price);

            modelBuilder
                .Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(k => k.ProductId);
        }
    }
}
