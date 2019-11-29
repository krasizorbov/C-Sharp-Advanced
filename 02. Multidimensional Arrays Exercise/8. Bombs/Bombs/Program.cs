using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[,] arr = new int[num, num];

            for (int r = 0; r < num; r++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int c = 0; c < num; c++)
                {
                    arr[r, c] = numbers[c];
                }
            }

            string[] bombs = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] coordinates = bombs[i].Split(',').Select(int.Parse).ToArray();

                int coorR = coordinates[0];
                int coorC = coordinates[1];

                for (int r = 0; r < num; r++)
                {
                    for (int c = 0; c < num; c++)
                    {
                        if (coorR == r && coorC == c)
                        {
                            if (arr[r,c] > 0)
                            {
                                int toRemove = arr[r, c];

                                if (r - 1 >= 0 && c - 1 >= 0 && arr[r - 1, c - 1] > 0)
                                {
                                    arr[r - 1, c - 1] = arr[r - 1, c - 1] - toRemove;
                                }
                                if (r - 1 >= 0 && c >= 0 && arr[r - 1, c] > 0)
                                {
                                    arr[r - 1, c] = arr[r - 1, c] - toRemove;
                                }
                                if (r - 1 >= 0 && c + 1 < num && arr[r - 1, c + 1] > 0)
                                {
                                    arr[r - 1, c + 1] = arr[r - 1, c + 1] - toRemove;
                                }
                                if (r >= 0 && c - 1 >= 0 && arr[r, c - 1] > 0)
                                {
                                    arr[r, c - 1] = arr[r, c - 1] - toRemove;
                                }
                                if (r >= 0 && c + 1 < num && arr[r, c + 1] > 0)
                                {
                                    arr[r, c + 1] = arr[r, c + 1] - toRemove;
                                }
                                if (r + 1 < num && c - 1 >= 0 && arr[r + 1, c - 1] > 0)
                                {
                                    arr[r + 1, c - 1] = arr[r + 1, c - 1] - toRemove;
                                }
                                if (r + 1 < num && c >= 0 && arr[r + 1, c] > 0)
                                {
                                    arr[r + 1, c] = arr[r + 1, c] - toRemove;
                                }
                                if (r + 1 < num && c + 1 < num && arr[r + 1, c + 1] > 0)
                                {
                                    arr[r + 1, c + 1] = arr[r + 1, c + 1] - toRemove;
                                }

                                arr[coorR, coorC] = 0;
                            }   
                        }
                    }
                }      
            }//for ends here

            int sum = 0;
            int counter = 0;

            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    if (arr[r,c] > 0)
                    {
                        sum += arr[r, c];
                        counter++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    Console.Write(arr[r,c] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
