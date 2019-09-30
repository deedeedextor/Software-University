using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.DrumSetME
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            List<int> drumSetOriginal = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> drumSet = new List<int>(drumSetOriginal);

            string[] command = Console.ReadLine().Split();

            while (command.Length == 1)
            {
                if (command.Length > 1)
                {
                    break;
                }

                int hitPower = int.Parse(command[0]);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        double drumPrice = drumSetOriginal[i] * 3.0;

                        if (budget >= drumPrice)
                        {
                            drumSet[i] = drumSetOriginal[i];
                            budget = budget - drumPrice;
                        }
                        else
                        {
                            if (drumSet[i] != drumSet[drumSet.Count - 1])
                            {
                                drumSet.RemoveAt(i);
                                drumSetOriginal.RemoveAt(i);

                                i = i - 1;
                            }
                            else
                            {

                                drumSet.RemoveAt(i);
                                drumSetOriginal.RemoveAt(i);
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {budget:F2}lv.");
        }
    }
}
