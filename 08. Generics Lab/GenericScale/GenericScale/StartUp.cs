using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var scale1 = new EqualityScale<int>(5, 10);
            Console.WriteLine(scale1.AreEqual());

            var scale2 = new EqualityScale<string>("Man", "Woman");
            Console.WriteLine(scale2.AreEqual());

            var scale3 = new EqualityScale<string>("Man", "Man");
            Console.WriteLine(scale3.AreEqual());
        }
    }
    public class EqualityScale<T>
    where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T AreEqual()
        {
            var comparison = left.CompareTo(right);

            if (comparison > 0)
            {
                return left;
            }
            else if (comparison < 0)
            {
                return right;
            }

            return default;
        }
    }
}
