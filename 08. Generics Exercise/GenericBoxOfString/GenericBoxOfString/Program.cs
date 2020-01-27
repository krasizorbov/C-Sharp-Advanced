using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
    }
    public class Box<T>
    {
        T myValue;
        public T MyValue { get => myValue; set => myValue = value; }

        public Box(T myValue)
        {
            MyValue = myValue;
        }
        public override string ToString()
        {
            return $"{myValue.GetType()}: {MyValue}";
        }
    }
}
