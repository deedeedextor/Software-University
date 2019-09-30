using System;

namespace _1.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] numberOfPeople = new int[numberOfWagons];
            int sum = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                 numberOfPeople[i] = int.Parse(Console.ReadLine());
                 sum += numberOfPeople[i];
            }
            Console.WriteLine(string.Join(" ", numberOfPeople));
            Console.WriteLine(sum);
        }
    }
}
