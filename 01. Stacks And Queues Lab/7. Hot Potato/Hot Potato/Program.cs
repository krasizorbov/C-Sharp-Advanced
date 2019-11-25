using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            int num = int.Parse(Console.ReadLine());

            var myQ = new Queue<string>(input);

            while (myQ.Count > 1)
            {
                for (int i = 1; i < num; i++)
                {
                    myQ.Enqueue(myQ.Dequeue());
                }

                Console.WriteLine($"Removed {myQ.Dequeue()}");
            }
            Console.WriteLine($"Last is {myQ.Peek()}");
        }
    }
}
