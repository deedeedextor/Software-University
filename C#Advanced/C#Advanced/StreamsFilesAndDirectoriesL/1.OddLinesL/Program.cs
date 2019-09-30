using System;
using System.IO;

namespace _1.OddLinesL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("./Input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
                    
            }
        }
    }
}
