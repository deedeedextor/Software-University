﻿namespace _12.GoogleE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Company
    {
        private string name;
        private string department;
        private decimal salary;

        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:F2}";
        }
    }
}
