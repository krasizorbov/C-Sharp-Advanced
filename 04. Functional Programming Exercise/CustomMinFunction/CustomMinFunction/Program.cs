using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = x => x.Min();

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(minNumber(array));
        }
    }
}
