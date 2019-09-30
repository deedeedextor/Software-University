namespace _5.GenericCountMethodStringsE
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();

                boxes.Add(new Box<string>(line));
            }

            string elementToCompare = Console.ReadLine();

            Console.WriteLine(CountGreater(boxes, elementToCompare));
        }

        static int CountGreater<T>(IEnumerable<Box<T>> collection, T element)
        where T : IComparable<T>
        {
            int counter = 0;

            foreach (var item in collection)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
