using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string result = string.Empty;
            
            for (int i = 0; i < count; i++)
            {
                char element = char.Parse(Console.ReadLine());
                result += element + " ";
            }
            Console.WriteLine(result+"!");
        }
    }
}
