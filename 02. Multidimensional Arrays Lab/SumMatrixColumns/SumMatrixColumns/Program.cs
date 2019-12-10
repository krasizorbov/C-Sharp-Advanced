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
            var arr = new int[r,c];
            int sum = 0;
            for (int i = 0; i < r; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < c; j++)
                {
                    arr[i,j] = input[j];
                }
            }

            int k = 0;
            while (k < c)
            {
                for (int i = 0; i < r; i++)
                {
                    sum += arr[i, k];
                }
                Console.WriteLine(sum);
                k = k + 1;
                sum = 0;
            }  
        }
    }
}
