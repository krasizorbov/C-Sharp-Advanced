using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] qNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int pushToQueue = qNumbers[0];
            int popFromQueue = qNumbers[1];
            int findInQueue = qNumbers[2];

            var myQ = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                myQ.Enqueue(numbers[i]);
            }

            for (int i = 0; i < popFromQueue; i++)
            {
                myQ.Dequeue();
            }

            if (myQ.Contains(findInQueue))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myQ.Count > 0)
                {
                    Console.WriteLine(myQ.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
