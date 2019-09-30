using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000DaysOnEarth
{
    class Program
    {
        static void Main(string[] args)
        {
            var inDate = Console.ReadLine();
            var outDate = DateTime.ParseExact(inDate, "dd-MM-yyyy", null);
            outDate = outDate.AddDays(1000);

            Console.WriteLine(outDate.ToString("dd-MM-yyyy"));
        }
    }
}
