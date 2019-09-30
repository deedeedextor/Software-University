using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceTargets = int.Parse(Console.ReadLine());
            int pokeExhaustion = int.Parse(Console.ReadLine());
            int pokePowerOriginal = pokePower * 50 / 100;
            int targetsCount = 0;

            while (pokePower >= distanceTargets)
            {
                pokePower -= distanceTargets;
                targetsCount++;

                if (pokePower == pokePowerOriginal && pokeExhaustion != 0)
                {
                    pokePower /= pokeExhaustion;
                }
            }
         
            Console.WriteLine($"{pokePower}\n{targetsCount}");
        }
    }
}
