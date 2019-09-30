using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < safe.Length; i += 2)
            {
                string item = safe[i];
                long amount = long.Parse(safe[i + 1]);

                var goldAmount = bag.Where(x => x.Key.Equals("Gold")).Sum(x => x.Value.Sum(z => z.Value));
                var gemAmount = bag.Where(x => x.Key.Equals("Gem")).Sum(x => x.Value.Sum(z => z.Value));
                var cashAmount = bag.Where(x => x.Key.Equals("Cash")).Sum(x => x.Value.Sum(z => z.Value));

                var type = GetType(item);

                long totalAmount = gemAmount + goldAmount + cashAmount;


                if (bagCapacity >= totalAmount + amount)
                {
                    if (type == "Gold")
                    {
                        //add to the bag
                        AddToBag(bag, item, amount, type);
                        continue;
                    }

                    if (type == "Gem" && gemAmount + amount <= goldAmount)
                    {
                        AddToBag(bag, item, amount, type);
                        continue;
                    }
                    if (type == "Cash" & cashAmount + amount <= gemAmount)
                    {
                        AddToBag(bag, item, amount, type);
                        continue;
                    }

                }

            }

            var dict = bag.OrderByDescending(x => x.Value.Sum(z => z.Value));

            foreach (var kvp in dict)
            {

                Console.WriteLine($"<{kvp.Key}> ${bag.Where(x => x.Key.Equals(kvp.Key)).Sum(x => x.Value.Sum(z => z.Value))}");
                foreach (var item in kvp.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void AddToBag(Dictionary<string, Dictionary<string, long>> bag, string wealth, long amount, string type)
        {
            if (!bag.ContainsKey(type))
            {
                bag.Add(type, new Dictionary<string, long>());
            }

            if (!bag[type].ContainsKey(wealth))
            {
                bag[type].Add(wealth, 0);
            }

            bag[type][wealth] += amount;

        }

        private static string GetType(string item)
        {
            if (item.Count() == 3)
            {
                return "Cash";
            }

            if (item.Length >= 4 && item.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }

            if (item.ToLower() == "gold")
            {
                return "Gold";
            }

            return "";
        }
    }


}