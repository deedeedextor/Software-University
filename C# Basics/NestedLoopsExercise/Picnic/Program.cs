using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picnic
{
    class Program
    {
        static void Main(string[] args)
        {           
            int quota = int.Parse(Console.ReadLine());
            double priceFish = 0;
            int countFish = 0;
            double fishSum = 0;

            while(true)
            {                           
                if (countFish == quota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }

                string fish = Console.ReadLine();

                if (fish == "Stop")
                {
                    break;
                }                   
                countFish++;

                double kgFish = double.Parse(Console.ReadLine());
                fishSum = 0;
              
                for (int i = 0; i < fish.Length; i++)
                {
                    fishSum += (int)fish[i];
                }

                fishSum /= kgFish;
                
                if (countFish % 3 == 0)
                {
                    priceFish += fishSum;
                }
                else
                {
                    priceFish -= fishSum;
                }               
            }
           
            if (priceFish > 0)
            {
                Console.WriteLine($"Lyubo's profit from {countFish} fishes is {Math.Abs(priceFish):F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(priceFish):F2} leva today.");
            }
        }
    }
}
