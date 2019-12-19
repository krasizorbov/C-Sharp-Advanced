using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Console.WriteLine(input.Count());
            Console.WriteLine(input.Sum());
        }
    }
}
