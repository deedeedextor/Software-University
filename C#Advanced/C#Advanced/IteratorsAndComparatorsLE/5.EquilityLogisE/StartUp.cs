
namespace _5.EquilityLogisE
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashPeople = new HashSet<Person>();
            SortedSet<Person> setPeople = new SortedSet<Person>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] personsTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personsTokens[0];
                int age = int.Parse(personsTokens[1]);

                hashPeople.Add(new Person(name, age));
                setPeople.Add(new Person(name, age));
            }

            Console.WriteLine(hashPeople.Count);
            Console.WriteLine(setPeople.Count);
        }
    }
}
