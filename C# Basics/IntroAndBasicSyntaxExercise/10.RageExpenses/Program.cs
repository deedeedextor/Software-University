using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());           

            int trashedHeadset = 0;
            int trashedMouse = 0;
            int trashedKeyboard = 0;
            int trashedDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }

                if (i % 3 == 0)
                {
                    trashedMouse++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyboard++;

                    if (trashedKeyboard % 2 == 0)
                    {
                        trashedDisplay++;
                    }
                }
            }

            double expenses = trashedHeadset * headsetPrice 
                + trashedMouse * mousePrice 
                + trashedKeyboard * keyboardPrice 
                + trashedDisplay * displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
