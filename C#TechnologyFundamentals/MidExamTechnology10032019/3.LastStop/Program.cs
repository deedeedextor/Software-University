using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintingNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string commands = Console.ReadLine();

            while (commands != "END")
            {
                string[] tokens = commands.Split();
                string command = tokens[0];

                if (command == "Change")
                {
                    int paintingNumber = int.Parse(tokens[1]);
                    int changedNumber = int.Parse(tokens[2]);

                    if (paintingNumbers.Contains(paintingNumber))
                    {
                        int index = paintingNumbers.IndexOf(paintingNumber);
                        paintingNumbers[index] = changedNumber;
                    }
                }

                else if (command == "Hide")
                {
                    int paintingNumber = int.Parse(tokens[1]);

                    if (paintingNumbers.Contains(paintingNumber))
                    {
                        paintingNumbers.Remove(paintingNumber);
                    }
                }

                else if (command == "Switch")
                {
                    int paintingNumber = int.Parse(tokens[1]);
                    int paintingNumber2 = int.Parse(tokens[2]);

                    if (paintingNumbers.Contains(paintingNumber) && paintingNumbers.Contains(paintingNumber2))
                    {
                        int index = paintingNumbers.IndexOf(paintingNumber);
                        int index2 = paintingNumbers.IndexOf(paintingNumber2);

                        int temp = paintingNumbers[index];
                        paintingNumbers[index] = paintingNumbers[index2];
                        paintingNumbers[index2] = temp;
                    }
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    int paintingNumber2 = int.Parse(tokens[2]);

                    if (index + 1 > 0 && index + 1 < paintingNumbers.Count)
                    {
                        paintingNumbers.Insert(index + 1, paintingNumber2);
                    }
                }

                else if (command == "Reverse")
                {
                    paintingNumbers.Reverse();
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", paintingNumbers));
        }
    }
}
