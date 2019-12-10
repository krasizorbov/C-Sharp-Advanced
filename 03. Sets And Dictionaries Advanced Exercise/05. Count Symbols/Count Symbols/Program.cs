using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            var myDic = new SortedDictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!myDic.ContainsKey(word[i]))
                {
                    myDic.Add(word[i], 1);
                }
                else
                {
                    myDic[word[i]]++;
                }
            }

            foreach (var item in myDic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
