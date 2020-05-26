using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char[][] matrix = new char[a][];
            int rF = 0;
            int cF = 0;
            int rS = 0;
            int cS = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                string row = Console.ReadLine();

                matrix[i] = new char[row.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = row[j];
                    if (matrix[i][j] == 'f')
                    {
                        rF = i;
                        cF = j;
                    }
                    if (matrix[i][j] == 's')
                    {
                        rS = i;
                        cS = j;
                    }
                }
            }
            string[] arr = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (true)
            {
                string first = arr[0].ToLower();
                string second = arr[1].ToLower();

                if (first == "up")
                {
                    if (rF == 0)
                    {
                        rF = matrix.Length - 1;
                        if (matrix[rF][cF] == 's')
                        {
                            matrix[rF][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][cF] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rF - 1][cF] == 's')
                        {
                            matrix[rF - 1][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[--rF][cF] = 'f';
                        }
                    }                 
                }
                else if (first == "left")
                {
                    if (cF == 0)
                    {
                        cF = matrix[rF].Length - 1;
                        if (matrix[rF][cF] == 's')
                        {
                            matrix[rF][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][cF] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rF][cF - 1] == 's')
                        {
                            matrix[rF][cF - 1] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][--cF] = 'f';
                        }
                    }
                }
                else if(first == "down")
                {
                    if (rF == matrix.Length - 1)
                    {
                        rF = 0;
                        if (matrix[rF][cF] == 's')
                        {
                            matrix[rF][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][cF] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rF + 1][cF] == 's')
                        {
                            matrix[rF + 1][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[++rF][cF] = 'f';
                        }
                    }
                }
                else if (first == "right")
                {
                    if (cF == matrix[rF].Length - 1)
                    {
                        cF = 0;
                        if (matrix[rF][cF] == 's')
                        {
                            matrix[rF][cF] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][cF] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rF][cF + 1] == 's')
                        {
                            matrix[rF][cF + 1] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rF][++cF] = 'f';
                        }
                    }
                }
                //starts form her

                if (second == "up")
                {
                    if (rS == 0)
                    {
                        rS = matrix.Length - 1;
                        if (matrix[rS][cS] == 'f')
                        {
                            matrix[rS][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][cS] = 's';
                        }
                    }
                    else
                    {
                        if (matrix[rS - 1][cS] == 'f')
                        {
                            matrix[rS - 1][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[--rS][cS] = 's';
                        }
                    }
                }
                else if (second == "left")
                {
                    if (cS == 0)
                    {
                        cS = matrix[rS].Length - 1;
                        if (matrix[rS][cS] == 'f')
                        {
                            matrix[rS][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][cS] = 's';
                        }
                    }
                    else
                    {
                        if (matrix[rS][cS - 1] == 'f')
                        {
                            matrix[rS][cS - 1] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][--cS] = 's';
                        }
                    }
                }
                else if (second == "down")
                {
                    if (rS == matrix.Length - 1)
                    {
                        rS = 0;
                        if (matrix[rS][cS] == 'f')
                        {
                            matrix[rS][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][cS] = 's';
                        }
                    }
                    else
                    {
                        if (matrix[rS + 1][cS] == 'f')
                        {
                            matrix[rS + 1][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[++rS][cS] = 's';
                        }
                    }
                }
                else if (second == "right")
                {
                    if (cS == matrix[rS].Length - 1)
                    {
                        cS = 0;
                        if (matrix[rS][cS] == 'f')
                        {
                            matrix[rS][cS] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][cS] = 's';
                        }
                    }
                    else
                    {
                        if (matrix[rS][cS + 1] == 'f')
                        {
                            matrix[rS][cS + 1] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[rS][++cS] = 's';
                        }
                    }
                }

                arr = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Print(matrix);
        }       
        public static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
