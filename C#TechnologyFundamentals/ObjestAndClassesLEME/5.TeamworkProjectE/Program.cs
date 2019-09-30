using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.TeamworkProjectE
{
    class Program
    {
        static void Main()
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = CreateTeams(countOfTeams);
            teams = AddMembers(teams);
            var orderedTeams = OrderTeams(teams);
            PrintTeams(orderedTeams);
        }

        private static void PrintTeams(List<Team> orderedTeams)
        {
            foreach (var team in orderedTeams.Where(m => m.TeamMembers.Count > 0))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.TeamCreator}");
                foreach (var tm in team.TeamMembers.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {tm}");
                }
            }
            Console.WriteLine($"Teams to disband:");

            foreach (var team in orderedTeams.Where(m => m.TeamMembers.Count == 0))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }

        private static List<Team> OrderTeams(List<Team> teams)
        {
            return teams.OrderByDescending(x => x.TeamMembers.Count).ThenBy(m => m.TeamName).ToList();
        }

        private static List<Team> AddMembers(List<Team> teams)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] splittedInput = input.Split("->");

                string memberName = splittedInput[0];
                string clubName = splittedInput[1];

                var currentTeam = teams.FirstOrDefault(n => n.TeamName == clubName);

                if (!teams.Any(t => t.TeamName == clubName))
                {
                    Console.WriteLine($"Team {clubName} does not exist!");
                    continue;
                }
                else if (teams.Any(n => n.TeamMembers.Contains(memberName))
                    || teams.Any(cr => cr.TeamCreator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {clubName}!");
                    continue;
                }
                else
                {
                    currentTeam.TeamMembers.Add(memberName);
                }
            }
            return teams;
        }

        private static List<Team> CreateTeams(int countOfTeams)
        {
            List<Team> teams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamProps = Console.ReadLine().Split("-");

                string teamName = teamProps[1];
                string teamCreator = teamProps[0];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if (teams.Any(t => t.TeamCreator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }
                else
                {
                    Team team = new Team()
                    {
                        TeamName = teamName,
                        TeamCreator = teamCreator,
                        TeamMembers = new List<string>()
                    };
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                    teams.Add(team);
                }
            }
            return teams;
        }
    }    

    class Team
    {
        public string TeamName { get; set; }

        public string TeamCreator { get; set; }

        public List<string> TeamMembers { get; set; }
    }
}
