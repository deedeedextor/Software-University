using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.AnonymousThreatE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "3:1")
            {
                if (command[0] == "3:1")
                {
                    break;
                }

                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);
                
                if (command[0] == "merge")
                {
                    startIndex = ChechIndex(startIndex, input.Count);
                    endIndex = ChechIndex(endIndex, input.Count);
                    Merge(input, startIndex, endIndex);
                }

                else if (command[0] == "divide")
                {
                    List<string> temp = new List<string>();
                    int partitions = endIndex;
                    string toDivide = input[startIndex];
                    int partLength = toDivide.Length / partitions;
                    int additionalPartLength = toDivide.Length % partitions;

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            partLength += additionalPartLength;
                        }

                        temp.Add(toDivide.Substring(0, partLength));
                        toDivide = toDivide.Remove(0, partLength);
                    }
                    input.RemoveAt(startIndex);
                    input.InsertRange(startIndex, temp);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static int ChechIndex(int index, int count)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index > count - 1)
            {
                index = count - 1;
            }
            return index;
        }

        private static List<string> Parts(string word, int divider)
        {
            List<string> result = new List<string>();

            int partLenght = word.Length / divider;

            for (int i = 0; i <= divider; i++)
            {
                if (i == divider - 1)
                {
                    result.Add(word.Substring(i * partLenght));
                }
                else
                {
                    result.Add(word.Substring(i * partLenght, partLenght));
                }
            }
            return result;
        }
    

        private static void Merge(List<string> input, int startIndex, int endIndex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                string word = input[i];
                sb.Append(word);
            }

            input.RemoveRange(startIndex, endIndex - startIndex + 1);
            input.Insert(startIndex, sb.ToString());
        }
    }
}