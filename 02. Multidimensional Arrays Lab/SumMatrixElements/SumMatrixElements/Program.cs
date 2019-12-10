using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
             
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int r = input[0];
            int c = input[1];
            var arr = new int[r, c];
            int sum = 0;
            for (int i = 0; i < r; i++)
            {
                input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < c; j++)
                {
                    arr[i, j] = input[j];
                }
            }
            foreach (var item in arr)
            {
                sum += item;
            }
            Console.WriteLine(r);
            Console.WriteLine(c);
            Console.WriteLine(sum);
        }
    }
}
