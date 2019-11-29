using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int minValue = int.MinValue;
            int sum = 0;
            int r = nums[0];
            int c = nums[1];
            int maxRow = 0;
            int maxCol = 0;
            int[,] arr = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < c; j++)
                {
                    arr[i, j] = numbers[j];
                }
            }

            for (int i = 0; i < r - 2; i++)
            {
                for (int j = 0; j < c - 2; j++)
                {
                    sum = arr[i, j] + arr[i + 1, j] + arr[i + 2, j] + arr[i, j + 1] + arr[i + 1, j + 1] + arr[i + 2, j + 1] + arr[i, j + 2] + arr[i + 1, j + 2] + arr[i + 2, j + 2];
                    if (sum > minValue)
                    {
                        minValue = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {minValue}");

            for (int i = maxRow; i <= maxRow + 2; i++)
            {
                for (int j = maxCol; j <= maxCol + 2; j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
