using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reverse_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack myStack = new Stack();
            
            StringBuilder sb = new StringBuilder(input);

            for (int i = 0; i < sb.Length; i++)
            {
                myStack.Push(sb[i]);
            }

            var sbFinal = new StringBuilder();

            foreach (var s in myStack)
            {
                sbFinal.Append(s);
            }

            Console.WriteLine(sbFinal);
        }
    }
}
