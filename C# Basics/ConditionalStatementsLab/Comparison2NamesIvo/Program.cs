using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparison2NamesIvo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter first name:");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter second name:");
            string secondName = Console.ReadLine().ToUpper();
            Console.WriteLine(name == secondName);
        }
    }
}
