using Microsoft.EntityFrameworkCore;
using MUSACA.Models;

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

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnestionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                   .HasKey(user => user.Id);

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Order>()
                .HasKey(order => order.Id);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.Products)
                .WithOne(orderProduct => orderProduct.Order)
                .HasForeignKey(orderProduct => orderProduct.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Cashier);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
