namespace _4.ComparingObjectsE
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Person> persons = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitInput = input.Split();
                string name = splitInput[0];
                int age = int.Parse(splitInput[1]);
                string town = splitInput[2];

                persons.Add(new Person(name, age, town));
            }

            int index = int.Parse(Console.ReadLine());

            Person currentPerson = persons[index - 1];

            int countEqual = 0;
            int countNotEqual = 0;

            for (int i = 0; i < persons.Count; i++)
            {
                if (currentPerson.CompareTo(persons[i]) == 0)
                {
                    countEqual++;
                }

                else
                {
                    countNotEqual++;
                }
            }

            if (countEqual > 1)
            {
                Console.WriteLine($"{countEqual} {countNotEqual} {persons.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
