using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var invited = new HashSet<string>();
            var present = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                invited.Add(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                present.Add(input);
                input = Console.ReadLine();
            }

            invited.ExceptWith(present);

            Console.WriteLine(invited.Count);

            foreach (var item in invited)
            {
                if (char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);
                }
            }

            foreach (var item in invited)
            {
                if (char.IsLetter(item[0]))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}