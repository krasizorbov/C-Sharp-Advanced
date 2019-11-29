using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] arr = new char[num, num];

            string[] input = Console.ReadLine().Split().ToArray();

            for (int r = 0; r < num; r++)
            {
                char[] symbols = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int c = 0; c < num; c++)
                {
                    arr[r, c] = symbols[c];
                }
            }

            int currR = 0;
            int currC = 0;

            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    if (arr[r,c] == 's')
                    {
                        currR = r;
                        currC = c;
                    }
                }
            }

            int counter = 0;
            int findCoal = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int r = 0; r < num; r++)
                {
                    for (int c = 0; c < num; c++)
                    {
                        if (currR == r && currC == c)
                        { 
                            if (input[i] == "left")
                            {
                                if (r >= 0 && r < num && c - 1 >= 0)
                                {
                                    if (arr[r, c - 1] == 'e')
                                    {
                                        Console.WriteLine($"Game over! {(r, c - 1)}");
                                        return;
                                    }
                                    else if (arr[r, c - 1] == 'c')
                                    {
                                        counter++;
                                        arr[r, c - 1] = '*';

                                        CheckForCoals(arr, num, findCoal);

                                        if (findCoal != 1)
                                        {
                                            Console.WriteLine($"You collected all coals! {(r, c - 1)}");
                                            return;
                                        }
                                    }
                                    currR = r;
                                    currC = c - 1;
                                    findCoal = 0;
                                    goto label;                                   
                                }
                            }
                            else if (input[i] == "right")
                            {
                                if (r >= 0 && r < num && c + 1 < num)
                                {
                                    if (arr[r, c + 1] == 'e')
                                    {
                                        Console.WriteLine($"Game over! {(r, c + 1)}");
                                        return;
                                    }
                                    else if (arr[r, c + 1] == 'c')
                                    {
                                        counter++;
                                        arr[r, c + 1] = '*';

                                        CheckForCoals(arr, num, findCoal);

                                        if (findCoal != 1)
                                        {
                                            Console.WriteLine($"You collected all coals! {(r, c + 1)}");
                                            return;
                                        }
                                    }
                                    currR = r;
                                    currC = c + 1;
                                    findCoal = 0;
                                    goto label;
                                }
                            }
                            else if (input[i] == "down")
                            {
                                if (r + 1 < num && c >= 0 && c < num)
                                {
                                    if (arr[r + 1, c] == 'e')
                                    {
                                        Console.WriteLine($"Game over! {(r + 1, c)}");
                                        return;
                                    }
                                    else if (arr[r + 1, c] == 'c')
                                    {
                                        counter++;
                                        arr[r + 1, c] = '*';

                                        CheckForCoals(arr, num, findCoal);

                                        if (findCoal != 1)
                                        {
                                            Console.WriteLine($"You collected all coals! {(r + 1, c)}");
                                            return;
                                        }
                                    }
                                    currR = r + 1;
                                    currC = c;
                                    findCoal = 0;
                                    goto label;
                                }
                            }
                            else if (input[i] == "up")
                            {
                                if (r - 1 >= 0 && c >= 0 && c < num)
                                {
                                    if (arr[r - 1, c] == 'e')
                                    {
                                        Console.WriteLine($"Game over! {(r - 1, c)}");
                                        return;
                                    }
                                    else if (arr[r - 1, c] == 'c')
                                    {
                                        counter++;
                                        arr[r - 1, c] = '*';

                                        CheckForCoals(arr, num, findCoal);

                                        if (findCoal != 1)
                                        {
                                            Console.WriteLine($"You collected all coals! {(r - 1, c)}");
                                            return;
                                        }
                                    }
                                    currR = r - 1;
                                    currC = c;
                                    findCoal = 0;
                                    goto label;
                                }
                            }
                        }//if ends here
                    }
                }
                label:;
            }//for ends here

            int sumCoals = 0;

            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    if (arr[r,c] == 'c')
                    {
                        sumCoals++;
                    }
                }
            }
            Console.WriteLine($"{sumCoals} coals left. {(currR, currC)}");
        }
        private static void CheckForCoals(char[,] arr, int num, int findCoal)
        {
            for (int m = 0; m < num; m++)
            {
                for (int n = 0; n < num; n++)
                {
                    if (arr[m, n] == 'c')
                    {
                        findCoal = 1;
                    }
                }
            }
        }
    }
}
