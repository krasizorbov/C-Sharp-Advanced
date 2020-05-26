using System;
using System.Linq;
using System.Text;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            string line = Console.ReadLine();

            int c = line.Length;

            char[,] arr = arr = new char[r, c];

            for (int i = 0; i < r; i++)
            {
                foreach (var l in line)
                {
                    sb.Append(l);
                }

                for (int j = 0; j < sb.Length; j++)
                {
                    arr[i, j] = sb[j];
                }
                sb.Clear();

                line = Console.ReadLine();
            }

            for (int m = 0; m < line.Length; m++)
            {
                if (line[m] == 'U')
                {
                    MoveEnemies(arr, r, c);
                    CheckKilled(arr, r, c);
                    SmovesUp(arr, r, c);
                    CheckKilled(arr, r, c); 
                }
                else if (line[m] == 'D')
                {
                    MoveEnemies(arr, r, c);
                    CheckKilled(arr, r, c);
                    SmovesDown(arr, r, c);
                    CheckKilled(arr, r, c);
                }
                else if (line[m] == 'L')
                {
                    MoveEnemies(arr, r, c);
                    CheckKilled(arr, r, c);
                    SmovesLeft(arr, r, c);
                    CheckKilled(arr, r, c);
                }
                else if (line[m] == 'R')
                {
                    MoveEnemies(arr, r, c);
                    CheckKilled(arr, r, c);
                    SmovesRight(arr, r, c);
                    CheckKilled(arr, r, c);
                }
                else if (line[m] == 'W')
                {
                    MoveEnemies(arr, r, c);
                    CheckKilled(arr, r, c);
                }
            }//command for
        }//main method ends here

        public static void PrintMatrix(char[,] arr, int r, int c)
        {
            for (int e = 0; e < r; e++)
            {
                for (int w = 0; w < c; w++)
                {
                    Console.Write(arr[e, w]);
                }
                Console.WriteLine();
            }
            System.Environment.Exit(0);
        }

        public static void CheckKilled(char[,] arr, int r, int c)
        {
            int colB = 0;
            int colD = 0;
            int colS = -1;
            int colN = 0;
            int rowB = 0;
            int rowD = 0;
            int rowS = -1;
            int rowN = 0;

            for (int l = 0; l < r; l++)
            {
                for (int n = 0; n < c; n++)
                {
                    if (arr[l, n] == 'b')
                    {
                        rowB = l;
                        colB = n;
                    }
                    else if (arr[l, n] == 'S')
                    {
                        rowS = l;
                        colS = n;
                    }
                    else if (arr[l, n] == 'd')
                    {
                        rowD = l;
                        colD = n;
                    }
                    else if (arr[l, n] == 'N')
                    {
                        rowN = l;
                        colN = n;
                    }

                    if (rowN == rowS)
                    {
                        Console.WriteLine("Nikoladze killed!");
                        arr[rowN, colN] = 'X';
                        PrintMatrix(arr, r, c);
                    }
                    else if (colB < colS && rowB == rowS)
                    {
                        Console.WriteLine($"Sam died at {rowS}, {colS}");
                        arr[rowS, colS] = 'X';
                        PrintMatrix(arr, r, c);
                    }
                    else if (colS < colD && rowD == rowS)
                    {
                        Console.WriteLine($"Sam died at {rowS}, {colS}");
                        arr[rowS, colS] = 'X';
                        PrintMatrix(arr, r, c);
                    }
                }//for ends here
            }//for ends here
        }

        public static void SmovesUp(char[,] arr, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arr[i, j] == 'S')
                    {  
                        if (i - 1 >= 0)
                        {
                            arr[i, j] = '.';
                            arr[i - 1, j] = 'S';
                            return;
                        }
                    }
                }
            }
        }

        public static void SmovesDown(char[,] arr, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arr[i, j] == 'S')
                    {  
                        if (i + 1 < r)
                        {
                            arr[i, j] = '.';
                            arr[i + 1, j] = 'S';
                            return;
                        }  
                    }
                }
            }
        }

        public static void SmovesLeft(char[,] arr, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arr[i, j] == 'S')
                    {
                        if (j - 1 >= 0)
                        {
                            arr[i, j] = '.';
                            arr[i, j - 1] = 'S';
                            return;
                        }
                    }
                }
            }
        }

        public static void SmovesRight(char[,] arr, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arr[i, j] == 'S')
                    {
                        if (j + 1 < c)
                        {
                            arr[i, j] = '.';
                            arr[i, j + 1] = 'S';
                            return;
                        } 
                    }
                }
            }
        }

        public static void MoveEnemies(char[,] arr, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arr[i, j] == 'b')
                    {
                        if (j == c - 1)
                        {
                            arr[i, j] = 'd';
                        }
                        else
                        {
                            arr[i, j] = '.';
                            arr[i, j + 1] = 'b';
                            j = j + 1;
                            continue;
                        }
                    }
                    else if (arr[i, j] == 'd')
                    {
                        if (j == 0)
                        {
                            arr[i, j] = 'b';
                        }
                        else
                        {
                            arr[i, j] = '.';
                            arr[i, j - 1] = 'd';
                        }
                    }
                }//second for
            }//first for
        }
    }
}
