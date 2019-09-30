using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FilterByAgeL
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] persons = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person
                {
                    Name = persons[0],
                    Age = int.Parse(persons[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filter;

            if (condition == "older")
            {
                filter = p => p.Age >= age;
            }

            else
            {
                filter = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> selectFunc = null;

            if (format == "name")
            {
                selectFunc = p => $"{p.Name}";
            }

            else if (format == "age")
            {
                selectFunc = p => $"{p.Age}";
            }

            else if (format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }

            people
                .Where(filter)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
