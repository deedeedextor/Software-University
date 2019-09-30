using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Month_Season
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();

            if ( month=="December" || month=="January" || month=="February")
            {
                Console.WriteLine("Winter is here");
            }
        }
    }
}
