using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.TakeSkipRopeME
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            List<int> numberList = new List<int>();
            List<char> text = new List<char>();

            foreach (var symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    int num = int.Parse(symbol.ToString());
                    numberList.Add(num);
                }
                else
                {
                    text.Add(symbol);
                }
            }

            List<int> takeEvenList = new List<int>();
            List<int> skipOddList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeEvenList.Add(numberList[i]);
                }
                else
                {
                    skipOddList.Add(numberList[i]);
                }
            }

            string result = string.Empty;
            var total = 0;

            for (int i = 0; i < skipOddList.Count; i++)
            {
                int skipCount = skipOddList[i];
                int takeCoun = takeEvenList[i];
                result += new string(text.Skip(total).Take(takeCoun).ToArray());
                total += skipCount + takeCoun;
            }

            Console.WriteLine(result);
        }
    }
}
