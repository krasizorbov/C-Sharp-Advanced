using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string value = Console.ReadLine();
                boxes.Add(new Box<string>(value));
            }

            int[] indices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indices[0], indices[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(IList<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
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
