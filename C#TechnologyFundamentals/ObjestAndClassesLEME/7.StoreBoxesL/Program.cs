using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StoreBoxesL
{
    
    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal BoxPrice { get; set; }
    };

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] tokens = input.Split();

                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);
                decimal boxPrice = itemQuantity * itemPrice;

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemName = itemName,
                    ItemQuantity = itemQuantity,
                    ItemPrice = itemPrice,
                    BoxPrice = boxPrice
                };
                boxes.Add(box);
                input = Console.ReadLine();
            }
            List<Box> sortedBoxes = boxes.OrderBy(o => o.BoxPrice).ToList();
            sortedBoxes.Reverse();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}\n-- {box.ItemName} - ${box.ItemPrice:F2}: {box.ItemQuantity}\n-- ${box.BoxPrice:F2}");
            };
        }
    }
}
