﻿namespace _5.EquilityLogisE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int resultName = this.Name.CompareTo(other.Name);

            if (resultName == 0)
            {
               return this.Age - other.Age;
            }

            return resultName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
