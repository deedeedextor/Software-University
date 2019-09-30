using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int christmasSpirit = 0;
            int sum = 0;

            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGarlands = 3;
            int treeLights = 15;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }

                if (i % 2 == 0)
                {
                    sum += ornamentSet * quantity;
                    christmasSpirit += 5;
                }

                if (i % 3 == 0)
                {
                    sum += (treeSkirt * quantity) + (treeGarlands * quantity);
                    christmasSpirit += 13;
                }

                if (i % 5 == 0)
                {
                    sum += treeLights * quantity;
                    christmasSpirit += 17;

                    if (i % 3 == 0)
                    {
                        christmasSpirit += 30;
                    }
                }

                if (i % 10 == 0)
                {
                    christmasSpirit -= 20;
                    sum += treeSkirt + treeGarlands + treeLights;

                    if (i == days)
                    {
                        christmasSpirit -= 30;
                    }
                }
            }
            Console.WriteLine($"Total cost: {sum}\nTotal spirit: {christmasSpirit}");
        }
    }
}
