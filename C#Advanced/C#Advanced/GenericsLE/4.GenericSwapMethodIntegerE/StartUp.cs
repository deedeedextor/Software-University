namespace _4.GenericSwapMethodIntegerE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int line = int.Parse(Console.ReadLine());

                boxes.Add(new Box<int>(line));
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap<int>(boxes, indexes[0], indexes[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void Swap<T>(List<Box<T>> boxes, int first, int second)
        {
            var temp = boxes[first];
            boxes[first] = boxes[second];
            boxes[second] = temp;
        }
    }
}
