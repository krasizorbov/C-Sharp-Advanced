using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var myDic = new Dictionary<double, int>();

            foreach (var item in numbers)
            {
                if (!myDic.ContainsKey(item))
                {
                    myDic.Add(item, 1);
                }
                else
                {
                    myDic[item]++;
                }
            }

            foreach (var item in myDic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
