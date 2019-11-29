using System;
using System.Linq;

namespace MatrixOfPalindroms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int r = arr[0];
            int c = arr[1];
            var matrix = new string[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = ((char)('a' + i)).ToString() + (char)('a' + i + j) + (char)('a' + i);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
