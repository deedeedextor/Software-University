using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int counter = 0;

            for (int i = username.Length -1; i >= 0; i--)
            {
                password += username[i];
            }
            
            string currentPassword = Console.ReadLine();

            while (currentPassword != password)
            {               
                counter++;

                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;                 
                }

                Console.WriteLine("Incorrect password. Try again.");

                currentPassword = Console.ReadLine();
            }

            if (counter < 4)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
