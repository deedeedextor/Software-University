using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.QuestsJournalExamsTechModul
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> quests = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Retire!")
            {
                string[] tokens = input.Split(" - ");

                string command = tokens[0];
                string quest = tokens[1];

                if (command == "Start")
                {
                    if (!quests.Contains(quest))
                    {
                        quests.Add(quest);
                    }
                }

                else if (command == "Complete")
                {
                    if (quests.Contains(quest))
                    {
                        quests.Remove(quest);
                    }
                }

                else if (command == "Side Quest")
                {
                    string[] questName = tokens[1].Split(":");

                    string questOne = questName[0];
                    string name = questName[1];

                    if (quests.Contains(questOne) && !quests.Contains(name))
                    {
                        int index = quests.IndexOf(questOne);

                        if (index == quests.Count - 1)
                        {
                            quests.Add(name);
                        }
                        else
                        {
                            quests.Insert(index + 1, name);
                        }

                    }
                }

                else if (command == "Renew")
                {
                    if (quests.Contains(quest))
                    {
                        int index = quests.IndexOf(quest);
                        quests.RemoveAt(index);
                        quests.Add(quest);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", quests));
        }
    }
}
