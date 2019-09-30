namespace _12.GoogleE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Person> people = GetPeople();

            PrintInformation(people);
        }

        private static void PrintInformation(Dictionary<string, Person> people)
        {
            string nameToPrint = Console.ReadLine();

            Person person = people.Values.FirstOrDefault(p => p.Name == nameToPrint);

            Console.WriteLine(person);
        }

        private static Dictionary<string, Person> GetPeople()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personTokens[0];

                if (!people.ContainsKey(name))
                {
                    people[name] = new Person(name);
                }

                string typeTokens = personTokens[1];

                switch (typeTokens)
                {
                    case "car":
                        string model = personTokens[2];
                        int speed = int.Parse(personTokens[3]);

                        people[name].AssignACar(new Car(model, speed));
                        break;
                    case "company":
                        string companyName = personTokens[2];
                        string department = personTokens[3];
                        decimal salary = decimal.Parse(personTokens[4]);

                        people[name].AssignACompany(new Company(companyName, department, salary));
                        break;
                    case "pokemon":
                        string pokemonName = personTokens[2];
                        string type = personTokens[3];

                        people[name].AddInCollection(new Pokemon(pokemonName, type));
                        break;
                    case "parents":
                        string parentName = personTokens[2];
                        string parentsBirthday = personTokens[3];

                        people[name].AddInCollection(new Parent(parentName, parentsBirthday));
                        break;
                    case "children":
                        string childName = personTokens[2];
                        string birthday = personTokens[3];

                        people[name].AddInCollection(new Child(childName, birthday));
                        break;
                }
            }

            return people;
        }
    }
}
