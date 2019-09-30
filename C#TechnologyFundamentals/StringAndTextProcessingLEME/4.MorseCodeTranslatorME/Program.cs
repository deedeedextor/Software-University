using System;
using System.Collections.Generic;
using System.Text;

namespace _4.MorseCodeTranslatorME
{
    class Program
    {
        static void Main(string[] args)
        {
            var morseCodeDictionary= new Dictionary<string, char>()
            {
                                       {".-", 'a'},
                                       {"-...", 'b'},
                                       {"-.-.", 'c'},
                                       {"-..", 'd'},
                                       {".",'e'},
                                       {"..-.",'f'},
                                       {"--.", 'g'},
                                       {"....",'h'},
                                       {"..",'i'},
                                       {".---",'j'},
                                       {"-.-",'k'},
                                       {".-..",'l'},
                                       {"--",'m'},
                                       {"-.",'n'},
                                       {"---",'o'},
                                       {".--.",'p'},
                                       {"--.-",'q'},
                                       {".-.",'r'},
                                       {"...",'s'},
                                       {"-",'t'},
                                       {"..-",'u'},
                                       {"...-",'v'},
                                       {".--",'w'},
                                       {"-..-",'x'},
                                       {"-.--",'y'},
                                       {"--..",'z'}
            };

            string input = Console.ReadLine();
            string[] splittedInput = input.Split();

            StringBuilder sb = new StringBuilder();

            foreach (var character in splittedInput)
            {
                if (morseCodeDictionary.ContainsKey(character))
                {
                    sb.Append(morseCodeDictionary[character]);
                }
                else if (character == "|")
                {
                    sb.Append(' ');
                }
            }
            Console.WriteLine(sb.ToString().ToUpper());
        }
    }
}
