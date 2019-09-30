using System;
using System.Collections.Generic;

namespace _1.ValidUsernameE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] usernames = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> userNamesFinal = new List<string>();

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool hasLength = ValidUsername(username);

                    if (hasLength)
                    {
                        userNamesFinal.Add(username); ;
                    }
                }
            }

            foreach (var username in userNamesFinal)
            {
                Console.WriteLine(username);
            }
        }

        private static bool ValidUsername(string username)
        {
            foreach (var chars in username)
            {
                if (char.IsLetterOrDigit(chars) || chars == '-' || chars == '_')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
