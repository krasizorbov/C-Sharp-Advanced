using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split();

            Stack<string> myStack = new Stack<string>(input.Reverse());

            while (myStack.Count > 1)
            {
                int lefOperand = int.Parse(myStack.Pop());
                string operation = myStack.Pop();
                int rightOperand = int.Parse(myStack.Pop());

                if (operation == "+")
                {
                    int sum = lefOperand + rightOperand;
                    myStack.Push(sum.ToString());
                }
                else if (operation == "-")
                {
                    int subtraction = lefOperand - rightOperand;
                    myStack.Push(subtraction.ToString());
                }
            }
            Console.WriteLine(myStack.Pop());
        }
    }
}
