using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = x => Console.WriteLine("Sir " + x);

            Console.ReadLine().Split().ToList().ForEach(printNames);
        }
    }
}
