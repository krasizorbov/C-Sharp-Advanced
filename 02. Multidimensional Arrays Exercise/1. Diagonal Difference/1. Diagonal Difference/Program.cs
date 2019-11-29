using System;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[,] arr = new int[num, num];

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    arr[i, j] = int.Parse(input[j]);
                }    
            }

            Console.WriteLine(difference(arr,num));
        }

        public static int difference(int[,] arr, int n)
        {
            int d1 = 0;
            int d2 = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        d1 += arr[i, j];
                    }
                    if (i == n - j - 1)
                    {
                        d2 += arr[i, j];
                    }
                }
            }
            return Math.Abs(d1 - d2);
        }
    }
}
