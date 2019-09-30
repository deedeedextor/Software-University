using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugsField = new int[fieldSize];

            int[] ladybugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < ladybugsField.Length; i++)
            {
                if (ladybugsIndexes.Contains(i))
                {
                    ladybugsField[i] = 1;
                }
            }


            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "end")
            {
                int ladybugIndex = int.Parse(input[0]);
                string direction = input[1];
                int flightLength = int.Parse(input[2]);

                if (ladybugIndex < 0 || ladybugIndex >= ladybugsField.Length)
                {
                    // podadeniq index ne e v poleto t.e e ili po malko ot nula ili po golqmo ot cqloto pole
                    input = Console.ReadLine().Split();
                    continue;
                }
                // ako nqma kalinka
                else if (ladybugsField[ladybugIndex] == 0)
                {
                    // chetem sledvashtiq red i ne pravim nishto
                    input = Console.ReadLine().Split();
                    continue;
                }
                else if (direction == "right")
                {
                    if (ladybugIndex + flightLength >= ladybugsField.Length)
                    {
                        ladybugsField[ladybugIndex] = 0;
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    else if (flightLength > 0)
                    {
                        FlyRight(ladybugIndex, flightLength, ladybugsField);
                    }
                    else if (flightLength < 0)
                    {
                        flightLength = Math.Abs(flightLength);

                        FlyLeft(ladybugIndex, flightLength, ladybugsField);
                    }
                }
                else if (direction == "left")
                {
                    if (ladybugIndex - flightLength < 0)
                    {
                        ladybugsField[ladybugIndex] = 0;
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    else if (flightLength > 0)
                    {
                        FlyLeft(ladybugIndex, flightLength, ladybugsField);
                    }
                    else if (flightLength < 0)
                    {
                        flightLength = Math.Abs(flightLength);

                        FlyRight(ladybugIndex, flightLength, ladybugsField);
                    }
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladybugsField));
        }

        public static void FlyRight(int startIndex, int flyLength, int[] field)
        {
            field[startIndex] = 0;

            for (int i = startIndex + flyLength; i < field.Length; i += flyLength)
            {
                if (field[i] == 1)
                {
                    continue;
                }
                else
                {
                    field[i] = 1;
                    return;
                }
            }
        }

        public static void FlyLeft(int startIndex, int flyLength, int[] field)
        {
            field[startIndex] = 0;

            for (int i = startIndex - flyLength; i >= 0; i -= flyLength)
            {
                if (field[i] == 1)
                {
                    continue;
                }
                else
                {
                    field[i] = 1;
                    return;
                }
            }
        }
    }
}