﻿namespace Andreys.Data
{
    using Andreys.Models;
    using Microsoft.EntityFrameworkCore;

    public class AndreysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder
                .UseSqlServer("Server=.\\SQLExpress;Database=AndreysDb;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
