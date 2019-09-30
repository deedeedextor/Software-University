using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                if (command == "Chat")
                {
                    string message = tokens[1];
                    messages.Add(message);
                }
                else if (command == "Delete")
                {
                    string message = tokens[1];

                    if (messages.Contains(message))
                    {
                        messages.Remove(message);
                    }
                }
                else if (command == "Edit")
                {
                    string message = tokens[1];
                    string editedVersion = tokens[2];

                    if (messages.Contains(message))
                    {
                        int index = messages.IndexOf(message);
                        messages[index] = editedVersion;
                    }
                }
                else if (command == "Pin")
                {
                    string message = tokens[1];

                    if (messages.Contains(message))
                    {
                        messages.Remove(message);
                        messages.Add(message);
                    }
                }
                else if (command == "Spam")
                {
                    string[] message = new string[tokens.Length];

                    for (int i = 1; i < tokens.Length; i++)
                    {
                        string spamMessages = tokens[i];
                        messages.Add(spamMessages);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in messages)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
