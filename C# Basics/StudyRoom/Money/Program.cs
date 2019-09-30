using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            double bitcoins = double.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine())/100;

            double bitcoinsToBGN = bitcoins * 1168;
            double yuansToUSD = yuans * 0.15;
            double USDToBGN = yuansToUSD * 1.76;

            double totalAmount = bitcoinsToBGN + USDToBGN;
            double totalAmountEUR = totalAmount / 1.95;
            double percentCommission = commission * totalAmountEUR;

            double result = totalAmountEUR - percentCommission;
            Console.WriteLine(result);
        }
    }
}
