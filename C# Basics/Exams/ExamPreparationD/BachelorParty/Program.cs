using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestSinger = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int guests = 0;
            int countGuests = 0;
            int totalAmount = 0;

            while (command != "The restaurant is full")
            {
                guests = int.Parse(command);
                countGuests += guests;

                if (guests < 5)
                {
                    guests *= 100;
                }
                else if (guests >= 5)
                {
                    guests *= 70;
                }
                totalAmount += guests;
                
                command = Console.ReadLine();

                if (command == "The restaurant is full")
                {
                    if (totalAmount >= guestSinger)
                    {
                        Console.WriteLine($"You have {countGuests} guests and {totalAmount - guestSinger} leva left.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You have {countGuests} guests and {totalAmount} leva income, but no singer.");
                        break;
                    }

                }
                
            }
        }
    }
}
