using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            
            if (day == "Friday")
            {
                if (type == "Students")
                {
                    price = persons * 8.45;
                }
                else if (type == "Business")
                {
                    price = persons * 10.90;
                }
                else if (type == "Regular")
                {
                    price = persons * 15;                  
                }
            }

            else if (day == "Saturday")
            {
                if (type == "Students")
                {
                    price = persons * 9.80;
                }
                else if (type == "Business")
                {
                    price = persons * 15.60;
                }
                else if (type == "Regular")
                {
                    price = persons * 20;
                }
            }

            else if (day == "Sunday")
            {
                if (type == "Students")
                {
                    price = persons * 10.46;
                }
                else if (type == "Business")
                {
                    price = persons * 16;
                }
                else if (type == "Regular")
                {
                    price = persons * 22.50;
                }
            }

            if (type == "Students" && persons >= 30)
            {
                price = price - (price * 0.15);
            }

            else if (type == "Business" && persons >= 100)
            {
                price = price - ((price / persons) * 10);
            }

            else if (type == "Regular" && (persons >= 10 && persons <= 20))
            {
                price = price - (price * 0.05);
            }
           
            Console.WriteLine($"Total price: {price:F2}");         
        }
    }
}
