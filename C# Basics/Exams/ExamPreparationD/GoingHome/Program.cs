using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingHome
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            int benzinExpense = int.Parse(Console.ReadLine());
            double benzinPrize = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            double carExpense = km * benzinExpense * benzinPrize / 100;
            double moneyLeft = Math.Abs(money - carExpense);

            if (money >= carExpense)
            {           
                Console.WriteLine($"You can go home. {moneyLeft:F2} money left.");
            }
            else
            {
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {(money / 5):F2} money.");
            }
        }
    }
}
