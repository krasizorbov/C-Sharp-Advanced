using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Max_And_Min_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (int i = 0; i < number; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    int numberToPush = input[1];
                    myStack.Push(numberToPush);
                }
                else if (input[0] == 2)
                {
                    if (myStack.Count > 0)
                    {
                        myStack.Pop();
                    }                  
                }
                else if (input[0] == 3)
                {
                    if (myStack.Count > 0)
                    {
                        Console.WriteLine($"{myStack.Max()}");
                    } 
                }
                else if (input[0] == 4)
                {
                    if (myStack.Count > 0)
                    {
                        Console.WriteLine($"{myStack.Min()}");
                    }  
                }
            }

            int[] arr = myStack.ToArray();

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
