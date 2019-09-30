using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCountL
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineWithWords = string.Empty;

            using (var reader = new StreamReader("./words.txt"))
            {
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    lineWithWords = line;
                    Console.WriteLine(lineWithWords);
                }
            }

            using (var reader = new StreamReader("./text.txt"))
            {
                string lineProps = string.Empty;
                var wordCount = new Dictionary<string, int>();

                using (var writer = new StreamWriter("output.txt"))
                {
                    while ((lineProps = reader.ReadLine()) != null)
                    {
                        string[] sentence = lineProps.ToLower().Split(new[] { '-',' ', ',', '?','!','.'}, StringSplitOptions.RemoveEmptyEntries);

                        string[] words = lineWithWords.Split();

                        foreach (var word in words)
                        {
                            for (int i = 0; i < sentence.Length; i++)
                            {
                                if (sentence[i] == word)
                                {
                                    if (!wordCount.ContainsKey(word))
                                    {
                                        wordCount[word] = 0;
                                    }
                                    wordCount[word]++;
                                }
                            }
                        }
                    }

                    foreach (var wordKvp in wordCount.OrderByDescending(x => x.Value))
                    {
                        string word = wordKvp.Key;
                        int count = wordKvp.Value;

                        writer.WriteLine($"{word} - {count}");
                        Console.WriteLine($"{word} - {count}");
                    }
                }
            }
        }
    }
}
