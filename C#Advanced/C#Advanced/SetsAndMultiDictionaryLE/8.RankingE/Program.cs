using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.RankingE
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentContests = new Dictionary<string, Dictionary<string, int>>();   //name-contest-points
            var contestPasswords = new Dictionary<string, string>();   //contest-password

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestsProps = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = contestsProps[0];
                string password = contestsProps[1];

                if (!contestPasswords.ContainsKey(contest))
                {
                    contestPasswords[contest] = password;
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] studentsProps = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = studentsProps[0];
                string pass = studentsProps[1];
                string student = studentsProps[2];
                int points = int.Parse(studentsProps[3]);

                if (contestPasswords.ContainsKey(contest) && contestPasswords[contest] == pass)
                {
                    if (!studentContests.ContainsKey(student))
                    {
                        studentContests[student] = new Dictionary<string, int>() { { contest, points } };
                    }

                    if (!studentContests[student].ContainsKey(contest))
                    {
                        studentContests[student].Add(contest, points);
                    }

                    if (studentContests[student][contest] < points)
                    {
                        studentContests[student][contest] = points;
                    }
                }
            }

            Dictionary<string, int> totalPoints = new Dictionary<string, int>();

            foreach (var kvp in studentContests)
            {
                totalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int bestPoints = totalPoints.Values.Max();

            foreach (var kvp in totalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {bestPoints} points.");
                }
            }

            Console.WriteLine("Ranking:");

            foreach (var kvp in studentContests.OrderBy(s => s.Key))
            {
                Dictionary<string, int> contestPoints = kvp.Value;
                contestPoints = contestPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"{kvp.Key}");
                foreach (var nestedKvp in contestPoints)
                {
                    Console.WriteLine($"#  {nestedKvp.Key} -> {nestedKvp.Value}");
                }
            }

        }
    }
}
