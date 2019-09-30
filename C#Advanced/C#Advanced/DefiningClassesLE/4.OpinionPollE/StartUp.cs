namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] peoplePromps = Console.ReadLine().Split();

                string name = peoplePromps[0];
                int age = int.Parse(peoplePromps[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> peopleOverThirty = family.PeopleOverThirty();
            Console.WriteLine(string.Join(Environment.NewLine, peopleOverThirty.OrderBy(n => n.Name)));
        }
    }
}
