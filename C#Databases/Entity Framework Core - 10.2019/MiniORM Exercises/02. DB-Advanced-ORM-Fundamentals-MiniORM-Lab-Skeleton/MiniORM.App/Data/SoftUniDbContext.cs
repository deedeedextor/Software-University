namespace MiniORM.App.Data
{
    using MiniORM.App.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
