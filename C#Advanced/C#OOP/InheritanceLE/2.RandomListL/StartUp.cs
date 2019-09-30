namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList();

            randomList.Add("Ivan");
            randomList.Add("Maria");
            randomList.Add("Pesho");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
