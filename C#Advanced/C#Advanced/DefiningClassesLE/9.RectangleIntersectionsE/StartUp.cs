namespace _9.RectangleIntersectionsE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numberOfRectangles = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();

            int rectanglesLines = numberOfRectangles[0];
            int intersections = numberOfRectangles[1];

            List<Rectangle> rectangles = GetRectangles(rectanglesLines);

            Print(rectangles, intersections);

        }

        private static void Print(List<Rectangle> rectangles, int intersections)
        {
            while (intersections > 0)
            {
                string[] rectangleTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var firstRect = rectangles.Where(r => r.Id == rectangleTokens[0]).FirstOrDefault();
                var secondRect = rectangles.Where(r => r.Id == rectangleTokens[1]).FirstOrDefault();

                Console.WriteLine(firstRect.IsThereIntersection(secondRect) ? "true" : "false");

                intersections--;
            }
        }

        private static List<Rectangle> GetRectangles(int rectanglesLines)
        {
           List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < rectanglesLines; i++)
            {
                string[] rectangleTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                rectangles.Add(new Rectangle(rectangleTokens[0],
                    double.Parse(rectangleTokens[1]),
                    double.Parse(rectangleTokens[2]),
                    double.Parse(rectangleTokens[3]),
                    double.Parse(rectangleTokens[4])));
            }

            return rectangles;
        }
    }
}
