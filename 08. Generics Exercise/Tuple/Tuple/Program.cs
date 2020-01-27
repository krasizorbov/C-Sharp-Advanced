using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            string name = $"{arr[0] + " " + arr[1]}";
            string address = arr[2];
            Tuple<string, string> t1 = new Tuple<string, string>(name, address);
            Console.WriteLine(t1);

            string[] arr1 = Console.ReadLine().Split().ToArray();
            string name1 = arr1[0];
            int address1 = int.Parse(arr1[1]);
            Tuple<string, int> t2 = new Tuple<string, int>(name1, address1);
            Console.WriteLine(t2);

            string[] arr2 = Console.ReadLine().Split().ToArray();
            int name2 = int.Parse(arr2[0]);
            double address2 = double.Parse(arr2[1]);
            Tuple<int, double> t3 = new Tuple<int, double>(name2, address2);
            Console.WriteLine(t3);
        }
    }
    public class Tuple<T1,T2>
    {
        T1 item1;
        T2 item2;
        public T1 Item1 { get => item1; set => item1 = value; }
        public T2 Item2 { get => item2; set => item2 = value; }
        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
