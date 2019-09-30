using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfTrojans = int.Parse(Console.ReadLine());

            int[] platesOfSpartans = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> trojans = null;
            List<int> spartans = new List<int>(platesOfSpartans);

            for (int i = 1; i <= wavesOfTrojans; i++)
            {
                int[] trojanWarriors = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                
                if (i % 3 == 0)
                {
                    int additionalSpartansPlate = int.Parse(Console.ReadLine());
                    spartans.Add(additionalSpartansPlate);
                }

                trojans = new Stack<int>(trojanWarriors);
                
                while (spartans.Any() && trojans.Any() && trojans.Peek() > 0)
                {
                    int currentTrojanWarrior = trojans.Pop();
                    int currentSpartansPlate = spartans[0];

                    if (currentSpartansPlate == 0)
                    {
                        spartans.RemoveAt(0);
                    }

                    if (currentTrojanWarrior < currentSpartansPlate)
                    {
                        currentSpartansPlate -= currentTrojanWarrior;
                        spartans[0] = currentSpartansPlate;
                    }

                    else if (currentTrojanWarrior > currentSpartansPlate)
                    {
                        trojans.Push(currentTrojanWarrior -= currentSpartansPlate);
                        spartans.RemoveAt(0);
                    }

                    else
                    {
                        spartans.RemoveAt(0);
                    }
                }

                if (i == wavesOfTrojans || spartans.Count == 0)
                {
                    break;
                }
            }


            if (spartans.Count == 0)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");

                if (trojans.Count != 0)
                {
                    Console.WriteLine($"Warriors left: {string.Join(", ", trojans)}");
                }
            }

            else if (trojans.Count == 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");

                if (spartans.Count != 0)
                {
                    Console.WriteLine($"Plates left: {string.Join(", ", spartans)}");
                }
            }
        }
    }
}
