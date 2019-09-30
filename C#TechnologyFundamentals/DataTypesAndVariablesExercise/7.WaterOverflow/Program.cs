using System;

namespace _7.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine()); //255liters           
            int volumeOfTank = 255;
            int litersInTank = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());

                if (volumeOfTank < quantityOfWater)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    volumeOfTank -= quantityOfWater;
                    litersInTank += quantityOfWater;
                }             
            }
            Console.WriteLine(litersInTank);
        }
    }
}
