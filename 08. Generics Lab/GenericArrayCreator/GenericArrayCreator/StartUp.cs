using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var array = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }
            return array;
        }
    }
}
