namespace _3.MankindE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.CheckFirstLetterIsUpper(value, nameof(this.firstName));

                this.ValidateLength(value, 4, nameof(this.firstName));
                
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.CheckFirstLetterIsUpper(value, nameof(this.lastName));

                this.ValidateLength(value, 3, nameof(this.lastName));

                this.lastName = value;
            }
        }

        private void ValidateLength(string value, int length, string name)
        {
            if (value.Length < length)
            {
                throw new ArgumentException($"Expected length at least {length} symbols! Argument: {name}");
            }

        }

        private void CheckFirstLetterIsUpper(string value, string name)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {name}");
            }
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine($"First Name: {this.firstName}");
            information.AppendLine($"Last Name: {this.lastName}");

            return information.ToString().TrimEnd();
        }
    }
}
