using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = nums[0];
            int c = nums[1];

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            string temp = string.Empty;
            string[,] arr = new string[r, c];

            for (int i = 0; i < r; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < c; j++)
                {
                    arr[i, j] = numbers[j];
                }
            }

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "END")
            {
                if (input[0] == "swap")
                {
                    if (input.Length == 5)
                    {
                        var isNumeric1 = false;
                        var isNumeric2 = false;
                        var isNumeric3 = false;
                        var isNumeric4 = false;

                        isNumeric1 = int.TryParse(input[1], out int n1);
                        isNumeric2 = int.TryParse(input[2], out int n2);
                        isNumeric3 = int.TryParse(input[3], out int n3);
                        isNumeric4 = int.TryParse(input[4], out int n4);

                        if (isNumeric1 && isNumeric2 && isNumeric3 && isNumeric4)
                        {
                            x1 = int.Parse(input[1]);
                            y1 = int.Parse(input[2]);
                            x2 = int.Parse(input[3]);
                            y2 = int.Parse(input[4]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }

                        if ((x1 >= 0 && x1 < r) && (x2 >= 0 && x2 < r) && (y1 >= 0 && y1 < c) && (y2 >= 0 && y2 < c))
                        {
                            temp = arr[x1, y1];
                            arr[x1, y1] = arr[x2, y2];
                            arr[x2, y2] = temp;

                            for (int i = 0; i < r; i++)
                            {
                                for (int j = 0; j < c; j++)
                                {
                                    Console.Write(arr[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");                   
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
    }
}
