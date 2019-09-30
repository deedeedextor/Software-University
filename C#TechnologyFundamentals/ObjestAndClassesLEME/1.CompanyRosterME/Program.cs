using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CompanyRosterME
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] employeesProps = Console.ReadLine().Split();

                string name = employeesProps[0];
                decimal salary = decimal.Parse(employeesProps[1]);
                string department = employeesProps[2];

                if (!departments.Any(x => x.DepartmentName == department))
                {
                    departments.Add(new Department(department));
                }

                departments.Find(x => x.DepartmentName == department).AddNewEmployee(name, salary);
            }

            Department theBestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {theBestDepartment.DepartmentName}");

            foreach (var employee in theBestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }

        }
    }

    class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Department
    {
        public Department(string department)
        {
            DepartmentName = department;
        }

        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddNewEmployee(string name, decimal salary)
        {
            TotalSalaries += salary;

            Employees.Add(new Employee(name, salary));
        }
    }
}
