using System;
using System.IO;

namespace _2.LineNumbersE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("text.txt"))
            {
                string line = string.Empty;
                int counter = 1;

                using (var writer = new StreamWriter("output.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        int letterCount = 0;
                        int symbolCount = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsPunctuation(line[i]))
                            {
                                symbolCount++;
                            }
                            else if (char.IsLetter(line[i]))
                            {
                                letterCount++;
                            }
                        }

                        line = $"Line {counter}:{line} ({letterCount})({symbolCount})";

                        writer.WriteLine(line);
                        Console.WriteLine(line);

                        counter++;
                    }
                }
            }
        }
    }
}
