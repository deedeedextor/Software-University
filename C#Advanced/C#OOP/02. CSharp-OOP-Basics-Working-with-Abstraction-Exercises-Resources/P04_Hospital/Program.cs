using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] data = command
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var departament = data[0];
                var doctor = data[1] + data[2];
                var patient = data[3];

                if (!doktors.ContainsKey(doctor))
                {
                    doktors[doctor] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int room = 1; room <= 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool hasSpace = departments[departament].SelectMany(x => x).Count() < 60;

                if (hasSpace)
                {
                    int room = 0;
                    doktors[doctor].Add(patient);

                    for (int bed = 0; bed < departments[departament].Count; bed++)
                    {
                        if (departments[departament][bed].Count < 3)
                        {
                            room = bed;
                            break;
                        }
                    }

                    departments[departament][room].Add(patient);
                }
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandParts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[commandParts[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)));
                }

                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[commandParts[0]][staq - 1]
                        .OrderBy(x => x)));
                }

                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doktors[commandParts[0] + commandParts[1]]
                        .OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
