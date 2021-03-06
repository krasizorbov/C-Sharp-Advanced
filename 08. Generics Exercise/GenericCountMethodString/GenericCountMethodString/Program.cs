﻿using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string value = Console.ReadLine();

                boxes.Add(new Box<string>(value));
            }

            string element = Console.ReadLine();

            int counter = CountGreater(boxes, element);
            Console.WriteLine(counter);
        }

        static int CountGreater<T>(IEnumerable<Box<T>> collection, T element)
            where T : IComparable<T>
        {
            int counter = 0;

            foreach (var item in collection)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
    public class Box<T> : IComparable<T>
    where T : IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(T other)
        {
            return value.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{value.GetType().FullName}: {value}";
        }
    }
}
