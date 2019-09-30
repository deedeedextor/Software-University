using System;
using System.Collections.Generic;
using System.Text;

namespace _6.CompanyRosterE
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            : this(name, salary, position, department)
        {
            this.Email = email;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { salary = value; }
        }

        public string Position
        {
            get { return this.position; }
            set { position = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { department = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { email = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { age = value; }
        }
    }
}
