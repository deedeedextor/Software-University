using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.OldestFamilyMemberME
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] memberProps = Console.ReadLine().Split();

                string name = memberProps[0];
                int age = int.Parse(memberProps[1]);

                family.AddMember(name, age);
            }

            Person theOldest = family.GetOldestMember();

            Console.WriteLine($"{theOldest.Name} {theOldest.Age}");
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(string name, int age)
        {
            Person newMember = new Person(name, age);

            FamilyMembers.Add(newMember);
        }

        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(x => x.Age).First();
        }
    }
}
