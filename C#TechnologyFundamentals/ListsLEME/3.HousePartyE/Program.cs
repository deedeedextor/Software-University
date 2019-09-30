using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HousePartyE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());          

            List<string> guests = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command.Length == 3)
                {
                    string name = command[0];
                    AddThePersonToTheList(guests, name);
                }

                else if (command.Length == 4)
                {
                    string name = command[0];
                    RemoveThePersonFromTheList(guests, name);
                }
            }
            Console.WriteLine(string.Join("\n", guests));
        }

        private static void RemoveThePersonFromTheList(List<string> guests, string str)
        {
            if (guests.Contains(str))
            {
                guests.Remove(str);
            }

            else
            {
                Console.WriteLine($"{str} is not in the list!");
            }
        }

        private static void AddThePersonToTheList(List<string> guests, string str)
        {
            if (!guests.Contains(str))
            {
                guests.Add(str);
            }

            else
            {
                Console.WriteLine($"{str} is already in the list!");
            }
        }
    }
}
