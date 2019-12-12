using System;
using System.Collections.Generic;
public class GroupContinents
{
    public static void Main()
    {
        var count = int.Parse(Console.ReadLine());

        var myDic = new Dictionary<string, Dictionary<string, List<string>>>();

        for (int i = 0; i < count; i++)
        {
            var tokens = Console.ReadLine().Split();

            var continent = tokens[0];
            var country = tokens[1];
            var city = tokens[2];

            if (!myDic.ContainsKey(continent))
            {
                myDic.Add(continent, new Dictionary<string, List<string>>());
            }

            if (!myDic[continent].ContainsKey(country))
            {
                myDic[continent].Add(country, new List<string>());
            }

            myDic[continent][country].Add(city);
        }

        foreach (var continent in myDic)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
}