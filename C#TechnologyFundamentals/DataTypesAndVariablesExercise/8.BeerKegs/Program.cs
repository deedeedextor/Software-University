using System;

namespace _8.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beerKegs = int.Parse(Console.ReadLine());
            double biggerVolume = 0;
            string isBigger = String.Empty;

            for (int i = 1; i <= beerKegs; i++)
            {
                string kegModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (biggerVolume < volume)
                {
                    biggerVolume = volume;
                    isBigger = kegModel;
                }
            }
            Console.WriteLine(isBigger);
        }
    }
}
