namespace _2.GenericBoxOfIntegerE
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int line = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(line);

                Console.WriteLine(box);
            }
        }
    }
}
