namespace GenericScale
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var first = 5;
            var second = 6;

            var scale = new EqualityScale<int>(first, second);
            
            Console.WriteLine(scale.AreEqual());
        }
    }
}
