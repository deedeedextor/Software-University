using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            double hours = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int employee = int.Parse(Console.ReadLine());

            double totalHours = 0.90 * days * employee * 10;

            if (totalHours >= hours)
            {
                Console.WriteLine("Yes!{0} hours left.", Math.Floor(totalHours - hours));
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", Math.Ceiling(hours - totalHours));
            }
        }
    }
}
