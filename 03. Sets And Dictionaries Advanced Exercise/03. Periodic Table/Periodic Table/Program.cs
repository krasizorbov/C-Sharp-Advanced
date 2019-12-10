using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var myHashSet = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] word = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < word.Length; j++)
                {
                    myHashSet.Add(word[j]);
                }
            }

            foreach (var item in myHashSet.OrderBy(x => x))
            {
                Console.Write(item + " ");
            }
        }
    }
}
