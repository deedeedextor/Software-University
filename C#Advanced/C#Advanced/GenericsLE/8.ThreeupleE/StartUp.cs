namespace _8.ThreeupleE
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(firstTuple.ToString());


            input = Console.ReadLine().Split();
            bool isDrunk = input[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine(secondTuple.ToString());

            input = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
