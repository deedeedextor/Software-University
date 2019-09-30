using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            Console.Write("Type your first name:");
            string myFirstName;
            myFirstName = Console.ReadLine();

            Console.Write("Type your last name:");
            string myLastName;
            myLastName = Console.ReadLine();

            Console.WriteLine("Hello," + myFirstName + " " + myLastName);
        }
    }
}
