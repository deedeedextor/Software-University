using System;

namespace _1.BinaryDigitsCountLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryToFind = int.Parse(Console.ReadLine());

            //string binary = Convert.ToString(number, 2);

            int counter = 0;

            while (number > 0)
            {
                int remander = number % 2;

                if (remander == binaryToFind)
                {
                    counter++;
                }
                number /= 2;
            }

            //for (int i = 0; i < binary.Length; i++)
            //{
              //  if (binary[i] - '0' == binaryToFind)
              //  {
                //    counter++;
                //}
            //}
            Console.WriteLine(counter);
        }
    }
}
