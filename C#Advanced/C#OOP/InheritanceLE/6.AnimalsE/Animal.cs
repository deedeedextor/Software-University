namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                this.CheckNullOrWhiteSpace(value);

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()) || value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }

            protected set
            {
                this.CheckNullOrWhiteSpace(value);

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Not implemented!";
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            information.AppendLine($"{this.ProduceSound()}");

            return information.ToString().TrimEnd();
        }

        private void CheckNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
        }
    }
}
