using System;
using System.Linq;
using System.Collections.Generic;

namespace Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];
            var nHash = new HashSet<int>();
            var mHash = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                nHash.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mHash.Add(int.Parse(Console.ReadLine()));
            }

            nHash.IntersectWith(mHash);
            foreach (var item in nHash)
            {
                Console.Write(item +" ");
            }
        }
    }
}
