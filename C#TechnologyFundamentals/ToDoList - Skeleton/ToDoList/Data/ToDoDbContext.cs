using ToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class ToDoDbContext : DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=ToDoListDb;IS";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
