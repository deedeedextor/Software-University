using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Latin alphabet:");

            for (int letter = 'a'; letter <= 'z'; letter ++)
            {
                Console.WriteLine(" " + letter);               
            }
        }
    }
}
