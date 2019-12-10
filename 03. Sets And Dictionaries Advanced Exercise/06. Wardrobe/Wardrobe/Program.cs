using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var myDic = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();

                string color = input[0];

                string[] items = input[1].Split(",").ToArray();

                if (!myDic.ContainsKey(color))
                {
                    myDic.Add(color, new Dictionary<string, int>());
                }
                if(myDic.ContainsKey(color))
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        if (!myDic[color].ContainsKey(items[j]))
                        {
                            myDic[color].Add(items[j], 1);
                        }
                        else
                        {
                            myDic[color][items[j]]++;
                        }
                    }  
                }         
            }

            string[] last = Console.ReadLine().Split().ToArray();

            string lastColor = last[0];
            string lastItem = last[1];

            foreach (var c in myDic)
            {
                Console.WriteLine($"{c.Key} clothes:");

                foreach (var item in c.Value)
                {
                    if (c.Key == lastColor && item.Key == lastItem)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }     
                }
            }
        }
    }
}
