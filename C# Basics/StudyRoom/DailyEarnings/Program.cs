using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyEarnings
{
    class Program
    {
        static void Main(string[] args)
        {
            int workingDays = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());
            double rateUSDToBGN = double.Parse(Console.ReadLine());

            double monthIncome = workingDays * moneyPerDay;
            double yearIncome = monthIncome * 12 + monthIncome * 2.5;
            double tax = 0.25 * yearIncome;
            double realYearIncomeBGN = (yearIncome - tax) * rateUSDToBGN;
            double BGNPerDay = realYearIncomeBGN / 365;

            Console.WriteLine($"{BGNPerDay:F2}");
        }
    }
}
