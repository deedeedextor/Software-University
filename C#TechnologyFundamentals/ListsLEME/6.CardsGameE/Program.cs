using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CardsGameE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                int firstCard = firstPlayerCards[0];
                int secondCard = secondPlayerCards[0];

                if (firstCard == secondCard)
                {
                    RemoveCards(firstPlayerCards, secondPlayerCards);
                }

                else if (firstCard > secondCard)
                {
                    RemoveCards(firstPlayerCards, secondPlayerCards);
                    firstPlayerCards.Add(firstCard);
                    firstPlayerCards.Add(secondCard);                  
                }
                else if (secondCard > firstCard)
                {
                    RemoveCards(firstPlayerCards, secondPlayerCards);
                    secondPlayerCards.Add(secondCard);
                    secondPlayerCards.Add(firstCard);
                }               
            }

            if (firstPlayerCards.Count > 0)
            {
                int sum = firstPlayerCards.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (secondPlayerCards.Count > 0)
            {
                int sum = secondPlayerCards.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }

        private static void RemoveCards(List<int> firstPlayerCards, List<int> secondPlayerCards)
        {
            firstPlayerCards.RemoveAt(0);
            secondPlayerCards.RemoveAt(0);
        }
    }
}
