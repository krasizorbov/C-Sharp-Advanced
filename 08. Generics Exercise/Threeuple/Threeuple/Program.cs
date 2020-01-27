using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            bool isDrunk = input[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
        }
    }
    public class Threeuple<T1, T2, T3>
    {
        private T1 item1;
        private T2 item2;
        private T3 item3;

        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
