namespace _3.Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] stonesValues = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stonesValues);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
