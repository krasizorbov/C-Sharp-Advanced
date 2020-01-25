using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace CustomStructure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();

            myStack.Push(1);
            myStack.Push(2);
            Action<int> action = x => Console.WriteLine(x);
            myStack.ForEach(action);
        }
    }
}
