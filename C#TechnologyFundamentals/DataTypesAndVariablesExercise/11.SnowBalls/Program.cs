using System;
using System.Numerics;

namespace _11.SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());            
            BigInteger biggerValue = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 1; i <= numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (biggerValue < snowballValue)
                {
                    biggerValue = snowballValue;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }              
            }
            Console.WriteLine($"{snow} : {time} = {biggerValue} ({quality})");
        }
    }
}
