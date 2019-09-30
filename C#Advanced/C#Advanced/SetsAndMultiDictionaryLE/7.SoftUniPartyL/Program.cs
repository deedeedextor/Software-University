using System;
using System.Collections.Generic;

namespace _7.SoftUniPartyL
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestsList = new HashSet<string>();
            var vipGuests = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }

                else
                {
                    guestsList.Add(input);
                }
            }

            if (input == "PARTY")
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    if (vipGuests.Contains(input))
                    {
                        vipGuests.Remove(input);
                    }

                    if (guestsList.Contains(input))
                    {
                        guestsList.Remove(input);
                    }
                }
            }

            Console.WriteLine($"{vipGuests.Count + guestsList.Count}");

            if (vipGuests.Count != 0)
            {
                foreach (var vip in vipGuests)
                {
                    Console.WriteLine(vip);
                }
            }

            if (guestsList.Count != 0)
            {
                foreach (var guest in guestsList)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
