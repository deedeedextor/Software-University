using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CompanyRosterE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmpoyees();

            PrintEmployeesWithHigherSalary(employees);
        }

        private static void PrintEmployeesWithHigherSalary(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                return;
            }

            var departmentHighestAverageSalary = employees
                .GroupBy(d => d.Department)
                .OrderByDescending(s => s.Select(sl => sl.Salary).Average())
                .First();

            Console.WriteLine($"Highest Average Salary: {departmentHighestAverageSalary.Key}");

            Console.WriteLine(string.Join(Environment.NewLine, departmentHighestAverageSalary
                .OrderByDescending(x => x.Salary)
                .Select(p => $"{p.Name} {p.Salary:F2} {p.Email} {p.Age}")));
        }

        private static List<Employee> GetEmpoyees()
        {
            List<Employee> employees = new List<Employee>();

            int numberOfEmplayees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmplayees; i++)
            {
                var email = "n/a";
                var age = -1;

                string[] employeeData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                /*string name = employeeData[0];
                decimal salary = decimal.Parse(employeeData[1]);
                string position = employeeData[2];
                string department = employeeData[3];*/

                if (employeeData.Length == 6)
                {
                    if (employeeData[4].Contains("@"))
                    {
                        email = employeeData[4];
                        age = int.Parse(employeeData[5]);
                    }

                    else
                    {
                        age = int.Parse(employeeData[4]);
                        email = employeeData[5];
                    }
                }

                else if (employeeData.Length == 5)
                {
                    if (employeeData[4].Contains("@"))
                    {
                        email = employeeData[4];
                    }

                    else
                    {
                        age = int.Parse(employeeData[4]);
                    }
                }

                employees.Add(new Employee(employeeData[0], 
                    decimal.Parse(employeeData[1]),
                    employeeData[2],
                    employeeData[3], 
                    email, age));
            }

            return employees;
        }
    }
}
