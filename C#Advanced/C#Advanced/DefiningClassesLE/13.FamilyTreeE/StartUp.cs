namespace _13.FamilyTreeE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var searchedPerson = Console.ReadLine();

            var allPeople = new List<Person>();

            CollectData(allPeople);
            PrintParentsAndChildren(allPeople, searchedPerson);
        }

        private static void PrintParentsAndChildren(List<Person> allPeople, string searchedPersonParam)
        {
            var person = allPeople.FirstOrDefault(p => (searchedPersonParam.Contains("/"))
                      ? p.BirthDate == searchedPersonParam
                      : p.Name == searchedPersonParam);

            var result = new StringBuilder();
            result.AppendLine($"{person.Name} {person.BirthDate}");

            result.AppendLine("Parents:");
            foreach (var parent in allPeople.Where(p => p.FindChildName(person.Name) != null))
            {
                result.AppendLine($"{parent.Name} {parent.BirthDate}");
            }

            result.AppendLine("Children:");
            foreach (var child in allPeople.FirstOrDefault(p => p.Name == person.Name).Children)
            {
                result.AppendLine($"{child.Name} {child.BirthDate}");
            }

            Console.WriteLine(result);
        }

        private static void CollectData(List<Person> allPeople)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains("-"))
                {
                    var tokens = input
                        .Split('-')
                        .Select(x => x.Trim())
                        .ToArray();

                    var parentParam = tokens[0];
                    var childParam = tokens[1];

                    var parent = allPeople.FirstOrDefault(p => (parentParam.Contains("/"))
                        ? p.BirthDate == parentParam
                        : p.Name == parentParam);

                    if (parent == null)
                    {
                        parent = (parentParam.Contains("/"))
                            ? new Person { BirthDate = parentParam }
                            : new Person { Name = parentParam };

                        allPeople.Add(parent);
                    }

                    var child = (childParam.Contains("/"))
                        ? new Person { BirthDate = childParam }
                        : new Person { Name = childParam };

                    parent.AddChild(child);
                }
                else
                {
                    var tokens = input.Split(' ');

                    var name = $"{tokens[0]} {tokens[1]}";
                    var date = tokens[2];
                    var isAdded = false;

                    for (int i = 0; i < allPeople.Count; i++)
                    {
                        if (allPeople[i].Name == name)
                        {
                            allPeople[i].BirthDate = date;
                            isAdded = true;
                        }

                        if (allPeople[i].BirthDate == date)
                        {
                            allPeople[i].Name = name;
                            isAdded = true;
                        }

                        allPeople[i].AddChildrenInfo(name, date);
                    }

                    if (!isAdded)
                    {
                        allPeople.Add(new Person(name, date));
                    }
                }
            }
        }
    }
}

