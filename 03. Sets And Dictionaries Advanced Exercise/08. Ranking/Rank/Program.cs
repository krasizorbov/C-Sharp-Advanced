using System;
using System.Linq;
using System.Collections.Generic;

namespace Rank
{
    class Program
    {
        static void Main(string[] args)
        {
            //contest.Key and password.Value
            var contestPassword = new Dictionary<string, string>();
            //username.Key and dictionary.Value(contest.Key and points.Value)
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(":").ToArray();

                if (input[0] == "end of contests")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];

                contestPassword.Add(contest, password);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>").ToArray();

                if (input[0] == "end of submissions")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                        users[username][contest] = points;
                    }
                    else if (!users[username].ContainsKey(contest))   //check for the "contest" in the dictionary inside dictioary if it doesn't exist
                    {
                        users[username][contest] = points; 
                    }
                    else if (users[username].ContainsKey(contest))    //check for the "contest" in the dictionary inside dictioary if it exists.
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                }
            }

            var namesAndPoints = new Dictionary<string, int>();    //Create new dictionary where "Name" is Key and "Max Sum" is Value.

            foreach (var name in users)
            {
                namesAndPoints.Add(name.Key, name.Value.Values.Sum());    //Add to the new dictionary.
            }

            //Print.
            foreach (var name in namesAndPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"Best candidate is {name.Key} with total {name.Value} points.");

                break;
            }

            Console.WriteLine("Ranking: ");

            foreach (var name in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(name.Key);

                foreach (var contest in name.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
