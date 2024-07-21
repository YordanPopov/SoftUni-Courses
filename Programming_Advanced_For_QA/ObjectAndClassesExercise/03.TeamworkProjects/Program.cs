namespace _03.TeamworkProjects
{
    internal class Program
    {
        class Team
        {
            public string Name { get; set; }

            public string Creator { get; set; }

            public List<string> Members { get; set; }

            public Team(string name, string creator)
            {
                this.Name = name;
                this.Creator = creator;
                Members = new List<string>();
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new();
            List<string> dispandTeams = new ();

            int countTeams = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countTeams; i ++)
            {
                string[] input = Console.ReadLine()
                                        .Split("-");

                string creator = input[0];
                string teamName = input[1];

                if (teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if(teams.Any(team => team.Value.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team currentTeam = new Team(teamName, creator);
                teams.Add(teamName, currentTeam);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string userName = command.Split("->")[0];
                string teamToJoin = command.Split("->")[1];

                if (!teams.ContainsKey(teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }

                else if (teams.Any(team => team.Value.Members.Contains(userName) || team.Value.Creator == userName))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamToJoin}!");
                }
                else
                {
                    teams[teamToJoin].Members.Add(userName);
                }


                command = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Team> team in teams.Where(team => team.Value.Members.Count == 0).OrderBy(team => team.Key))
            {
                dispandTeams.Add(team.Key);
            }

            foreach (KeyValuePair<string, Team> team in teams.Where(t => t.Value.Members.Count > 0).OrderByDescending(t => t.Value.Members.Count).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{team.Key}");
                Console.WriteLine($"- {team.Value.Creator}");

                foreach (var member in team.Value.Members.OrderBy(member => member))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in dispandTeams)
            {
                Console.WriteLine($"{team}");
            }

        }
    }
}