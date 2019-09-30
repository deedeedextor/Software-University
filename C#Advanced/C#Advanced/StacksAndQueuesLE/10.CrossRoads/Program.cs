
using System;
using System.Collections.Generic;

namespace _10.CrossroadsE
{
    class Program
    {
        static void Main(string[] args)
        {
            var crossroadQueue = new Queue<string>();    

            int greenSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int passedCarCount = 0;
            bool isCrashed = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    crossroadQueue.Enqueue(input);
                }

                else if (input == "green")
                {
                    int currentGreenLight = greenSeconds;

                    while (crossroadQueue.Count != 0 && currentGreenLight > 0)
                    {
                        string car = crossroadQueue.Dequeue();
                        int carLength = car.Length;

                        if (currentGreenLight - carLength >= 0)
                        {
                            passedCarCount++;
                            currentGreenLight -= carLength;
                        }

                        else
                        {
                            currentGreenLight += freeWindowSeconds;

                            if (currentGreenLight - carLength >= 0)
                            {
                                passedCarCount++;
                                break;
                            }

                            else
                            {
                                int crashedLetter = currentGreenLight;

                                isCrashed = true;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[crashedLetter]}.");
                                break;
                            }
                        }

                    }
                }
            }

            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarCount} total cars passed the crossroads.");
            }
        }
    }
}
