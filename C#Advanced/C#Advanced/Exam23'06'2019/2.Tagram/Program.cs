using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var tagram = new Dictionary<string, Dictionary<string, int>>();  //username-tags-likes

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input.Contains("ban"))
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string user = tokens[1];

                    if (tagram.ContainsKey(user))
                    {
                        tagram.Remove(user);
                    }
                }

                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string user = tokens[0];
                    string tags = tokens[1];
                    int likes = int.Parse(tokens[2]);
                    bool isAdded = false;

                    if (!tagram.ContainsKey(user))
                    {
                        tagram[user] = new Dictionary<string, int>() { { tags, likes } };
                        isAdded = true;
                    }

                    if (!tagram[user].ContainsKey(tags))
                    {
                        isAdded = true;
                        tagram[user].Add(tags, likes);
                    }

                    if (!isAdded && tagram[user].ContainsKey(tags))
                    {
                        tagram[user][tags] += likes;
                    }
                }
            }

            var sortedTagram = tagram.SelectMany(i => i.Value, (key, inner)
                => new { Outer = key, Inner = inner.Key, Value = inner.Value })
                .OrderByDescending(e => e.Value).ThenBy(e => e.Inner);

            foreach (var kvp in sortedTagram)
            {
                string user = kvp.Outer.Key;

                Console.WriteLine($"{user}");

                foreach (var nestedKvp in tagram[user])
                {
                    string tag = nestedKvp.Key;
                    int likes = nestedKvp.Value;

                    Console.WriteLine($"- {tag}: {likes}");
                }
            }
        }
    }
}
