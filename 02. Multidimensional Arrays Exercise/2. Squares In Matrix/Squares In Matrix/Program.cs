using System;
using System.Collections.Generic;
using System.Linq;
namespace Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int counter = 0;
            int r = nums[0];
            int c = nums[1];
            char[,] arr = new char[r,c];

            for (int i = 0; i < r; i++)
            {
                char[] symbols = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < c; j++)
                {
                    arr[i, j] = symbols[j];
                 }
            }

            for (int i = 0; i < r - 1; i++)
            {
                for (int j = 0; j < c - 1; j++)
                {
                    if (arr[i, j] == arr[i, j + 1] && arr[i, j] == arr[i + 1, j] && arr[i, j] == arr[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
