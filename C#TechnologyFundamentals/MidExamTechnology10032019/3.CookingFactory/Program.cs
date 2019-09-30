using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bestBatch = new int[] { int.MinValue };
            int bestQuality = int.MinValue;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bake It!")
            {
                int[] currentBatch = input.Split('#').Select(int.Parse).ToArray(); 
                int currentQuality = currentBatch.Sum();                           
                bool foundBetterBatch = false;       

                if (bestQuality < currentQuality)    
                {
                    foundBetterBatch = true;
                }
                else if (bestQuality == currentQuality)                        
                {
                    if (bestBatch.Average() < currentBatch.Average())          
                    {
                        foundBetterBatch = true;
                    }
                    else if (bestBatch.Average() == currentBatch.Average() &&  
                             bestBatch.Length > currentBatch.Length)           
                    {
                        foundBetterBatch = true;
                    }
                }

                if (foundBetterBatch)                          
                {
                    bestBatch = (int[])currentBatch.Clone();   
                    bestQuality = bestBatch.Sum();             
                }
            }

            Console.WriteLine($"Best Batch quality: {bestQuality}\n{string.Join(" ", bestBatch)}");
        }
    }
}

