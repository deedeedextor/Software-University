namespace _1.GenericBoxOfStringE
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<string> values = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();

                Box<string> box = new Box<string>(line);

                Console.WriteLine(box);
            }
        }
    }
}
