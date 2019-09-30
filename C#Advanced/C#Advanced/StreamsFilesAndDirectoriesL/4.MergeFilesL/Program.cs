using System;
using System.Collections.Generic;
using System.IO;

namespace _4.MergeFilesL
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedNumbers = new SortedSet<string>();

            using (var reader = new StreamReader("FileOne.txt"))
            {
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    sortedNumbers.Add(line);
                    //Console.WriteLine(string.Join(" ", sortedNumbers));
                }
            }

            using (var reader = new StreamReader("FileTwo.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    string secondLine = string.Empty;

                    while ((secondLine = reader.ReadLine()) != null)
                    {
                        sortedNumbers.Add(secondLine);
                    }

                    foreach (var number in sortedNumbers)
                    {
                        writer.WriteLine(number);
                        Console.WriteLine(number);
                    }
                }
            }
        }
    }
}
