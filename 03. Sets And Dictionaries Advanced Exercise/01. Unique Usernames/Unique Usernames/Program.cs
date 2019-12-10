using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var myHash = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                myHash.Add(name);
            }

            foreach (var name in myHash)
            {
                Console.WriteLine(name);
            }
        }
    }
}
