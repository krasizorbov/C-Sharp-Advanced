using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> myQ = new Queue<int>();

            var list = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                myQ.Enqueue(numbers[i]);
            }

            while (myQ.Count >= 1)
            {
                if (myQ.Peek() % 2 == 0)
                {
                    list.Add(myQ.Dequeue());
                }
                else
                {
                    myQ.Dequeue();
                }
            }
            
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
