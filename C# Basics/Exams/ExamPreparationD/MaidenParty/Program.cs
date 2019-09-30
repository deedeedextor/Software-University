using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMaidenParty = double.Parse(Console.ReadLine());
            int loveLetters = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int keys = int.Parse(Console.ReadLine());
            int caricature = int.Parse(Console.ReadLine());
            int luckSurprises = int.Parse(Console.ReadLine());
            double income = 0;

            double totalSum = loveLetters * 0.60 + roses * 7.20 + keys * 3.60 + caricature * 18.20 + luckSurprises * 22;
            int numberOfProducts = loveLetters + roses + keys + caricature + luckSurprises;

            if (numberOfProducts >= 25)
            {
                double totalSumDiscount = totalSum * 0.65;
                income = totalSumDiscount * 0.90;
            }
            else
            {
                income = totalSum * 0.90;
            }

            if (income >= priceMaidenParty)
            {
                Console.WriteLine($"Yes! {(income-priceMaidenParty):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(priceMaidenParty-income):F2} lv needed.");
            }
           
        }
    }
}
