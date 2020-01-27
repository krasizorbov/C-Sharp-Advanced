﻿using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box<int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int value = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(value));
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
