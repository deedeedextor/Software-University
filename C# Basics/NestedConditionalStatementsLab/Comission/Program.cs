using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comission
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double comission = -1.0;

            if (town == "sofia")
            {
                if(0 <= sales && sales <= 500)
                {
                    comission = 0.05;
                }
                else if(500 < sales && sales <= 1000)
                {
                    comission = 0.07;
                }
                else if(1000 < sales && sales <= 10000)
                {
                    comission = 0.08;
                }
                else if(sales > 10000)
                {
                    comission = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if(town == "varna")
            {
                if (0 <= sales && sales <= 500)
                {
                    comission = 0.045;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comission = 0.075;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comission = 0.10;
                }
                else if (sales > 10000)
                {
                    comission = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if(town == "plovdiv")
            {
                if (0 <= sales && sales <= 500)
                {
                    comission = 0.055;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comission = 0.08;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comission = 0.12;
                }
                else if (sales > 10000)
                {
                    comission = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            if(comission >= 0)
            {
                Console.WriteLine("{0:F2}", (sales * comission));
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
