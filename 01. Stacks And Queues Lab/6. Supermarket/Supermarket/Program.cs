using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesQ = new Queue<string>();

            string name = Console.ReadLine();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    foreach (var item in namesQ)
                    {
                        Console.WriteLine(item);
                    }
                    namesQ.Clear();
                }
                else
                {
                    namesQ.Enqueue(name);
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{namesQ.Count} people remaining.");
        }
    }
}
