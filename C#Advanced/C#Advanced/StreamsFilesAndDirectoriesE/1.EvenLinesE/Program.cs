using System;
using System.IO;
using System.Linq;

namespace _1.EvenLinesE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("text.txt"))
            {
                string line = string.Empty;
                int counter = 0;
                char[] symbols = new char[] { '-', ',', '.', '!', '?' };

                using (var writer = new StreamWriter("output.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string changedLine = string.Empty;

                        if (counter % 2 == 0)
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                if (symbols.Contains(line[i]))
                                {
                                    changedLine += '@';
                                }

                                else
                                {
                                    changedLine += line[i];
                                }
                            }

                            string[] splittedLine = changedLine.Split();
                            Array.Reverse(splittedLine);

                            writer.WriteLine(string.Join(" ", splittedLine));
                            Console.WriteLine(string.Join(" ", splittedLine));
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
