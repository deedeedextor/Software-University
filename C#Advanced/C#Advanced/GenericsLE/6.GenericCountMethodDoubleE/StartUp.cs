namespace _6.GenericCountMethodDoubleE
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                double line = double.Parse(Console.ReadLine());

                boxes.Add(new Box<double>(line));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(CountGreater(boxes, elementToCompare));
        }

        public static int CountGreater<T>(IEnumerable<Box<T>> collection, T element)
        where T : IComparable<T>
        {
            int counter = 0;

            foreach (var item in collection)
            {
                if (item.CompareTo(element) > 0.0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}

