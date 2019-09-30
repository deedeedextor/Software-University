namespace Telephony
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new Smartphone("Smartphone");

            WorkWithPhone(phone);
        }

        private static void WorkWithPhone(Smartphone phone)
        {
            var numbersToCall = Console.ReadLine()
                .Split();

            foreach (var number in numbersToCall)
            {
                Console.WriteLine(phone.Call(number));
            }

            var urlToVisit = Console.ReadLine()
                .Split();

            foreach (var url in urlToVisit)
            {
                Console.WriteLine(phone.Browse(url));
            }
        }
    }
}
