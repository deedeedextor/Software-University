using System;

namespace _5.DateModifierE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDaysBetweenTwoDates(firstDate, secondDate));
        }
    }
}
