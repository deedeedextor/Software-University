namespace _3.MankindE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workingHours;

        public Worker(string firstName, string lastName, double weekSalary, double workingHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkingHours
        {
            get
            {
                return this.workingHours;
            }

            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            return (this.weekSalary / 5) / this.workingHours;
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine(base.ToString());
            information.AppendLine($"Week Salary: {this.weekSalary:F2}");
            information.AppendLine($"Hours per day: {this.workingHours:F2}");
            information.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():F2}");

            return information.ToString().TrimEnd();
        }
    }
}
