namespace MiniORM.App
{
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=; Database=;";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employees
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });
            
            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            //context.Employees.Add(new Employees
            //{
            //    FirstName = "Mariq",
            //    LastName = "Georgieva",
            //    DepartmentId = context.Departments.First().Id,
            //    IsEmployed = true,
            //});
            //
            //var employee = context.Employees.Last();
            //employee.LastName = "Boikova";

            //var employeeToDelete = context.Employees
            //    .FirstOrDefault(e => e.FirstName == "Mariq");

            //Remove method throws exception
            //context.Employees.Remove(employeeToDelete); 

            context.SaveChanges();
        }
    }
}
