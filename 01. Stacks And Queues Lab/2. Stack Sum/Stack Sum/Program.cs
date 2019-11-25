using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                myStack.Push(numbers[i]);
            }

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "add")
                {
                    int firstNumber = int.Parse(input[1]);
                    int secondNumber = int.Parse(input[2]);

                    myStack.Push(firstNumber);
                    myStack.Push(secondNumber);
                }
                else if (input[0].ToLower() == "remove")
                {
                    int elementsToremove = int.Parse(input[1]);

                    if (elementsToremove <= myStack.Count)
                    {
                        for (int j = 0; j < elementsToremove; j++)
                        {
                            myStack.Pop();
                        }
                    }
                }
                input = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"Sum: {myStack.Sum()}");
        }
    }
}
