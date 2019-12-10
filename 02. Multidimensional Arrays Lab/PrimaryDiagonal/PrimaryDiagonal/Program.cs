using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var arr = new int[num, num];

            for (int i = 0; i < num; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < num; j++)
                {
                    arr[i, j] = input[j];
                }
            }
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += arr[i, i];
            }
            Console.WriteLine(sum);
        }
    }
}
