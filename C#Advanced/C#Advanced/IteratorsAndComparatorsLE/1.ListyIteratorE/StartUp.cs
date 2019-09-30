namespace _1.ListyIteratorE
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            ListyIterator<string> listyIterator = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                if (command == "Create")
                {
                    listyIterator = new ListyIterator<string>(tokens.Skip(1).ToList());
                }

                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }

                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }

                else if (command == "Print")
                {
                    Console.WriteLine(listyIterator.Print());
                }

                else if (command == "PrintAll")
                {
                    foreach (var element in listyIterator)
                    {
                        Console.Write(element + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
