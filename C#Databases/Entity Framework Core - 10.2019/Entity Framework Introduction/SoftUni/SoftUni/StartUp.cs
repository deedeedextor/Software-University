using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(RemoveTown(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} " +
                    $"{employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .Where(d => d.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeNakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employeeNakov.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var employee in context.Employees
                                            .Include(e => e.Manager)
                                            .Include(e => e.EmployeesProjects)
                                            .ThenInclude(e => e.Project)
                                            .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                             && ep.Project.StartDate.Year <= 2003))
                                            .Select(e => new
                                            {
                                                e.EmployeeId,
                                                e.FirstName,
                                                e.LastName,
                                                ManagerFirstName = e.Manager.FirstName,
                                                ManagerLastName = e.Manager.LastName
                                            })
                                            .Take(10)
                                            .ToList())
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in context.Projects
                                               .Where(e => e.EmployeesProjects.Any(ep => ep.EmployeeId == employee.EmployeeId)))
                {
                    string format = "M/d/yyyy h:mm:ss tt";
                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString(format, CultureInfo.InvariantCulture)} " +
                        $"- {(project.EndDate == null ? "not finished" : project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture))}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var address in context.Addresses
                                            .Select(a => new { 
                                                              a.AddressText,
                                                              TownName = a.Town.Name,
                                                              EmployeeCount = a.Employees.Count
                                                              })
                                            .Take(10)
                                            .OrderByDescending(a => a.EmployeeCount)
                                            .ThenBy(a => a.TownName)
                                            .ThenBy(a => a.AddressText)
                                            .ToList())
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees.Find(147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in context.Projects
                                           .Where(p => p.EmployeesProjects.Any(ep => ep.EmployeeId == employee.EmployeeId))
                                           .OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var department in context.Departments
                                              .Select(d => new { 
                                                                d.Employees,
                                                                d.Name,
                                                                d.Manager.FirstName,
                                                                d.Manager.LastName
                                                      })
                                              .Where(d => d.Employees.Count > 5)
                                              .OrderBy(e => e.Employees.Count)
                                              .ThenBy(d => d.Name))
            {
                sb.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");

                foreach (var employee in department.Employees
                                                   .Select(e => new { 
                                                                    e.FirstName,
                                                                    e.LastName,
                                                                    e.JobTitle
                                                                    })
                                                   .OrderBy(e => e.FirstName)
                                                   .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var project in context.Projects
                                           .OrderByDescending(p => p.StartDate)
                                           .Take(10)
                                           .OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            decimal increase = 1.12M;

            foreach (var employee in context.Employees
                                            .Select(e => new {
                                                             e.FirstName,
                                                             e.LastName,
                                                             increasedSalary = e.Salary * increase,
                                                             e.Department,
                                            })
                                            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                                            || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                                            .OrderBy(e => e.FirstName)
                                            .ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.increasedSalary:F2})");
            }

            //string[] departmentsList =
            //{
            //    "Engineering",
            //    "Tool Design",
            //    "Marketing",
            //    "Information Services"
            //};
            //
            //foreach (var e in context.Employees
            //    .Where(e => departmentsList.Contains(e.Department.Name)))
            //{
            //    e.Salary *= 1.12m;
            //}
            //
            //context.SaveChanges();
            //
            //foreach (var e in context.Employees
            //    .Where(e => departmentsList.Contains(e.Department.Name))
            //    .OrderBy(e => e.FirstName)
            //    .ThenBy(e => e.LastName))
            //{
            //    sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            //}

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var e in context.Employees
                                     .Select(e => new {
                                                       e.FirstName,
                                                       e.LastName,
                                                       e.JobTitle,
                                                       e.Salary
                                     })
                                     .Where(e => e.FirstName.StartsWith("Sa"))
                                     .OrderBy(e => e.FirstName)
                                     .ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context.Projects.Find(2);

            foreach (var ep in context.EmployeesProjects
                                      .Where(ep => ep.Project == project))
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            foreach (var p in context.Projects.Take(10))
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                  .Where(e => e.Address.Town.Name == "Seattle")
                  .ToList();

            foreach (var e in employees)
            {
                e.AddressId = null;
                context.SaveChanges();
            }
            var towns = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToList();

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            int countAddresses = addresses.Count();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }

            foreach (var town in towns)
            {
                context.Towns.Remove(town);
                context.SaveChanges();
            }

            return $"{countAddresses} addresses in Seattle were deleted";
        }
    }
}
