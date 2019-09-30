namespace _7.TupleE
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string> firstTuple = new Tuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(firstTuple.ToString());


            input = Console.ReadLine().Split();
            Tuple<string, int> secondTuple = new Tuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(secondTuple.ToString());

            input = Console.ReadLine().Split();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
