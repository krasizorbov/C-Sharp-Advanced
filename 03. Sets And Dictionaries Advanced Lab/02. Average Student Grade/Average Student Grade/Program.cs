using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var myDic = new Dictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!myDic.ContainsKey(name))
                {
                    var list = new List<double>();
                    list.Add(grade);
                    myDic.Add(name, list);
                }
                else
                {
                    myDic[name].Add(grade);
                }
            }

            foreach (var s in myDic)
            {
                Console.Write($"{s.Key} -> ");

                foreach (var grade in s.Value)
                {
                    Console.Write($"{grade:F2} ");
                    
                }

                Console.Write($"(avg: {s.Value.Average():F2})");

                Console.WriteLine();
            }
        }
    }
}
