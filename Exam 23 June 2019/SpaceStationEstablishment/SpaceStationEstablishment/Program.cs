using System;
namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            var matrix = new char[r][];

            int stefanR = 0;
            int stefanC = 0;
            //bool blackhole = false;
            int energy = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                string input = Console.ReadLine();
                matrix[i] = new char[input.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (input[j] == 'S')
                    {
                        stefanR = i;
                        stefanC = j;
                    }
                    matrix[i][j] = input[j];
                }
            }
            matrix[stefanR][stefanC] = '-';
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    matrix[stefanR][stefanC] = '-';
                    stefanR = stefanR - 1;
                    if (isInside(matrix, stefanR, stefanC))
                    {
                        if (matrix[stefanR][stefanC] == 'O')
                        {
                            matrix[stefanR][stefanC] = '-';
                        }
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                if (matrix[i][j] == 'O')
                                {
                                    matrix[i][j] = 'S';
                                    stefanR = i;
                                    stefanC = j;
                                }
                            }
                        }
                        if (char.IsDigit(matrix[stefanR][stefanC]))
                        {
                            int toAdd = matrix[stefanR][stefanC] - '0';
                            matrix[stefanR][stefanC] = '-';
                            energy = energy + toAdd;
                            if (energy >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {energy}");
                                matrix[stefanR][stefanC] = 'S';
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[stefanR + 1][stefanC] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {energy}");
                        break;
                    }
                }

                if (command == "down")
                {
                    matrix[stefanR][stefanC] = '-';
                    stefanR = stefanR + 1;
                    if (isInside(matrix, stefanR, stefanC))
                    {
                        if (matrix[stefanR][stefanC] == 'O')
                        {
                            matrix[stefanR][stefanC] = '-';
                        }
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                if (matrix[i][j] == 'O')
                                {
                                    matrix[i][j] = 'S';
                                    stefanR = i;
                                    stefanC = j;
                                }
                            }
                        }
                        if (char.IsDigit(matrix[stefanR][stefanC]))
                        {
                            int toAdd = matrix[stefanR][stefanC] - '0';
                            matrix[stefanR][stefanC] = '-';
                            energy = energy + toAdd;
                            if (energy >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {energy}");
                                matrix[stefanR][stefanC] = 'S';
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[stefanR - 1][stefanC] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {energy}");
                        break;
                    }
                }

                if (command == "left")
                {
                    matrix[stefanR][stefanC] = '-';
                    stefanC = stefanC - 1;
                    if (isInside(matrix, stefanR, stefanC))
                    {
                        if (matrix[stefanR][stefanC] == 'O')
                        {
                            matrix[stefanR][stefanC] = '-';
                        }
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                if (matrix[i][j] == 'O')
                                {
                                    matrix[i][j] = 'S';
                                    stefanR = i;
                                    stefanC = j;
                                }
                            }
                        }
                        if (char.IsDigit(matrix[stefanR][stefanC]))
                        {
                            int toAdd = matrix[stefanR][stefanC] - '0';
                            matrix[stefanR][stefanC] = '-';
                            energy = energy + toAdd;
                            if (energy >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {energy}");
                                matrix[stefanR][stefanC] = 'S';
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[stefanR][stefanC + 1] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {energy}");
                        break;
                    }
                }

                if (command == "right")
                {
                    matrix[stefanR][stefanC] = '-';
                    stefanC = stefanC + 1;
                    if (isInside(matrix, stefanR, stefanC))
                    {
                        if (matrix[stefanR][stefanC] == 'O')
                        {
                            matrix[stefanR][stefanC] = '-';
                        }
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                if (matrix[i][j] == 'O')
                                {
                                    matrix[i][j] = 'S';
                                    stefanR = i;
                                    stefanC = j;
                                }
                            }
                        }
                        if (char.IsDigit(matrix[stefanR][stefanC]))
                        {
                            int toAdd = matrix[stefanR][stefanC] - '0';
                            matrix[stefanR][stefanC] = '-';
                            energy = energy + toAdd;
                            if (energy >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {energy}");
                                matrix[stefanR][stefanC] = 'S';
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[stefanR][stefanC - 1] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {energy}");
                        break;
                    }
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
        private static bool isInside(char[][] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
