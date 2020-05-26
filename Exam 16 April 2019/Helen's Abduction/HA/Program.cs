using System;
using System.Linq;

namespace HA
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());
            var matrix = new char[r][];
            int Prow = 0;
            int Pcol = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                string input = Console.ReadLine();
                matrix[i] = new char[input.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (input[j] == 'P')
                    {
                        Prow = i;
                        Pcol = j;
                    }
                    matrix[i][j] = input[j];
                }
            }
            matrix[Prow][Pcol] = '-';

            while (true)
            {
                string[] arr = Console.ReadLine().Split().ToArray();
                string direction = arr[0];
                int targetR = int.Parse(arr[1]);
                int targetC = int.Parse(arr[2]);

                matrix[targetR][targetC] = 'S';
                energy--;

                if (direction == "up")
                {
                    if (Prow - 1 >= 0)
                    {
                        Prow--;
                    }
                    if (energy <= 0)
                    {
                        matrix[Prow][Pcol] = 'X';
                        End(Prow, Pcol);
                        break;
                    }
                }
                else if (direction == "down")
                {
                    if (Prow + 1 < matrix.Length)
                    {
                        Prow++;
                    }
                    if (energy <= 0)
                    {
                        matrix[Prow][Pcol] = 'X';
                        End(Prow, Pcol);
                        break;
                    }
                }
                else if (direction == "left")
                {
                    if (Pcol - 1 >= 0)
                    {
                        Pcol--;
                    }
                    if (energy <= 0)
                    {
                        matrix[Prow][Pcol] = 'X';
                        End(Prow, Pcol);
                        break;
                    }
                }
                else if (direction == "right")
                {
                    if (Pcol + 1 < matrix[Prow].Length)
                    {
                        Pcol++;
                    }
                    if (energy <= 0)
                    {
                        matrix[Prow][Pcol] = 'X';
                        End(Prow, Pcol);
                        break;
                    }
                }
                if (matrix[Prow][Pcol] == 'S')
                {
                    energy -= 2;
                    if (energy <= 0)
                    {
                        matrix[Prow][Pcol] = 'X';
                        End(Prow, Pcol);
                        break;
                    }
                    else
                    {
                        matrix[Prow][Pcol] = '-';
                    }
                }
                if (matrix[Prow][Pcol] == 'H')
                {
                    matrix[Prow][Pcol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }
            }
            PrintWithoutSpaces(matrix);
        }
        private static void PrintWithoutSpaces(char[][] matrix) // Print the array WITHOUT SPACES
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
        private static void End(int r, int c)
        {
            Console.WriteLine($"Paris died at {r};{c}.");
        }
    }
}