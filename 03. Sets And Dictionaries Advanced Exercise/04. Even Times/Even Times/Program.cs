using System;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var myDic = new Dictionary<int, int>();

            for (int i = 0; i < num; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (!myDic.ContainsKey(numbers))
                {
                    myDic.Add(numbers, 1);
                }
                else
                {
                    myDic[numbers]++;
                }
            }

            foreach (var item in myDic)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key); 
                }
            }
        }
    }
}
