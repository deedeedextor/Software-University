using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TheV_LoggerE
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLoggers = new Dictionary<string, int[]>(); // name - followers - following
            var vLoggersFollowers = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string[] joinedVloggers = input.Split();
                    string vLoggerName = joinedVloggers[0];

                    if (!vLoggers.ContainsKey(vLoggerName))
                    {
                        vLoggers[vLoggerName] = new int[2];
                        vLoggers[vLoggerName][0] = 0;
                        vLoggers[vLoggerName][1] = 0;
                    }
                }

                else if (input.Contains("followed"))
                {
                    string[] followerAndFollowed = input.Split();
                    string follower = followerAndFollowed[0];
                    string followed = followerAndFollowed[2];

                    if (follower != followed)
                    {
                        if (vLoggers.ContainsKey(follower) && vLoggers.ContainsKey(followed))
                        {
                            if (!vLoggersFollowers.ContainsKey(followed))
                            {
                                vLoggersFollowers[followed] = new List<string>();
                            }

                            if (!vLoggersFollowers[followed].Contains(follower))
                            {
                                vLoggersFollowers[followed].Add(follower);

                                vLoggers[follower][1]++;
                                vLoggers[followed][0]++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            int i = 0;

            foreach (var loggerKvp in vLoggers.OrderByDescending(f => f.Value[0]).ThenBy(fl => fl.Value[1]))
            {
                i++;

                string name = loggerKvp.Key;
                int followers = loggerKvp.Value[0];
                int following = loggerKvp.Value[1];

                Console.WriteLine($"{i.ToString()}. {name} : {followers} followers, {following} following");

                if (i == 1 && followers > 0)
                {
                    foreach (var follower in vLoggersFollowers[name].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
