using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stackNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int pushToStack = stackNumbers[0];
            int popFromStack = stackNumbers[1];
            int findInStack = stackNumbers[2];

            var myStack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                myStack.Push(numbers[i]);
            }

            for (int i = 0; i < popFromStack; i++)
            {
                myStack.Pop();
            }

            if (myStack.Contains(findInStack))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myStack.Count > 0)
                {
                    Console.WriteLine(myStack.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
