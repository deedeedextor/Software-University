namespace Ferrari
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string driversName = Console.ReadLine();

            Ferrari ferrari = new Ferrari("488-Spider", driversName);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
