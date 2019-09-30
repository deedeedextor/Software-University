namespace _3.MankindE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            private set
            {
                if ((value.Length < 5 || value.Length > 10) || 
                    !value.All(x => char.IsLetterOrDigit(x)))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine(base.ToString());
            information.AppendLine($"Faculty number: {this.facultyNumber}");

            return information.ToString().TrimEnd();
        }
    }
}
