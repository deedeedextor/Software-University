﻿namespace MiniORM.App.Data
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeesProjects { get; set; }
    }
}
