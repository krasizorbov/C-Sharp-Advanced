using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>(clothesValues);

            int sum = 0;
            int counter = 1;

            while (myStack.Count > 0)
            {
                sum += myStack.Peek();
                if (sum <= capacity)
                {
                    myStack.Pop();
                }
                else
                {
                    counter++;
                    sum = 0;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
