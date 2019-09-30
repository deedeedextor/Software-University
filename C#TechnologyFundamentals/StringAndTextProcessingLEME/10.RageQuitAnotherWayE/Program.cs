using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace ReplaceRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine().ToUpper();

            List<char> chars = new List<char>();
            string repeatText = string.Empty;
            string textNumber = string.Empty;
            int realNumber = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                chars.Add(input[i]);
            }

            for (int i = 0; i < chars.Count; i++)
            {

                if (char.IsLetter(chars[i]) || !char.IsNumber(chars[i]))
                {
                    repeatText += chars[i];

                    if (char.IsNumber(chars[i + 1]))
                    {
                        textNumber += chars[i + 1];

                        try
                        {
                            if (char.IsNumber(chars[i + 2]))
                            {
                                textNumber += chars[i + 2];
                            }
                        }
                        catch
                        {

                        }
                        realNumber = int.Parse(textNumber);

                        for (int j = 1; j <= realNumber; j++)
                        {
                            sb.Append(repeatText);
                        }
                        repeatText = string.Empty;
                        realNumber = 0;
                        textNumber = string.Empty;

                    }
                }
            }
            string symbols = sb.ToString();
            List<char> finalChars = new List<char>();

            foreach (var item in symbols)
            {
                if (!finalChars.Contains(item))
                {
                    finalChars.Add(item);
                }
            }
            Console.WriteLine($"Unique symbols used: {finalChars.Count}");
            Console.WriteLine(sb);
        }
    }
}
