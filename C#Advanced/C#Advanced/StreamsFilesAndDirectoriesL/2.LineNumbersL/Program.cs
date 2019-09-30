using System;
using System.IO;

namespace _2.LineNumbersL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    string line = string.Empty;
                    int counter = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        line = $"{counter}. {line}";

                        writer.WriteLine(line);
                        counter++;
                    }
                }
            }
        }
    }
}
