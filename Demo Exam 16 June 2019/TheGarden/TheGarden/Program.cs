using System;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            var matrix = new char[r][];
            int carrotCount = 0;
            int potatoCount = 0;
            int lettuceCount = 0;
            int harmedCount = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                matrix[i] = new char[input.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = input[j];
                }
            }

            while (true)
            {
                string[] arr = Console.ReadLine().Split().ToArray();

                if (arr[0] == "Harvest")
                {
                    int row = int.Parse(arr[1]);
                    int col = int.Parse(arr[2]);
                    bool isTrue = false;
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        for (int j = 0; j < matrix[i].Length; j++)
                        {
                            if (isInside(matrix, row, col))
                            {
                                if (matrix[row][col] == 'L')
                                {
                                    lettuceCount++;
                                    matrix[row][col] = ' ';
                                    isTrue = true;
                                    break;
                                }
                                else if (matrix[row][col] == 'P')
                                {
                                    potatoCount++;
                                    matrix[row][col] = ' ';
                                    isTrue = true;
                                    break;
                                }
                                else if (matrix[row][col] == 'C')
                                {
                                    carrotCount++;
                                    matrix[row][col] = ' ';
                                    isTrue = true;
                                    break;
                                }
                            }
                            else
                            {
                                isTrue = true;
                                break;
                            }
                        }
                        if (isTrue == true)
                        {
                            break;
                        }
                    }
                }
                else if (arr[0] == "Mole")
                {
                    int row = int.Parse(arr[1]);
                    int col = int.Parse(arr[2]);
                    string direction = arr[3];

                    if (direction == "up")
                    {
                        if (isInside(matrix, row, col))
                        {
                            Check(matrix, row, col);

                            for (int i = row; i >= 0; i -= 2)
                            {
                                if (matrix[i][col] == ' ')
                                {
                                    continue;
                                }
                                else
                                {
                                    matrix[i][col] = ' ';
                                    harmedCount++;
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        if (isInside(matrix, row, col))
                        {
                            Check(matrix, row, col);

                            for (int i = row; i < matrix.Length; i += 2)
                            {
                                if (matrix[i][col] == ' ')
                                {
                                    continue;
                                }
                                else
                                {
                                    matrix[i][col] = ' ';
                                    harmedCount++;
                                }
                            }
                        } 
                    }
                    else if (direction == "right")
                    {
                        if (isInside(matrix, row, col))
                        {
                            Check(matrix, row, col);

                            for (int i = col; i < matrix[row].Length; i += 2)
                            {
                                if (matrix[row][i] == ' ')
                                {
                                    continue;
                                }
                                else
                                {
                                    matrix[row][i] = ' ';
                                    harmedCount++;
                                }
                            }
                        } 
                    }
                    else if (direction == "left")
                    {
                        if (isInside(matrix, row, col))
                        {
                            Check(matrix, row, col);

                            for (int i = matrix[row].Length - 1; i >= 0; i -= 2)
                            {
                                if (matrix[row][i] == ' ')
                                {
                                    continue;
                                }
                                else
                                {
                                    matrix[row][i] = ' ';
                                    harmedCount++;
                                }
                            }
                        }  
                    }
                }
                else
                {
                    break;
                }
            }

            Print(matrix);
            Console.WriteLine($"Carrots: {carrotCount}");
            Console.WriteLine($"Potatoes: {potatoCount}");
            Console.WriteLine($"Lettuce: {lettuceCount}");
            Console.WriteLine($"Harmed vegetables: {harmedCount}");
        }

        private static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
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

        private static void Check(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'L')
            {
                matrix[row][col] = 'M';
            }
            else if (matrix[row][col] == 'P')
            {
                matrix[row][col] = 'M';
            }
            else if (matrix[row][col] == 'C')
            {
                matrix[row][col] = 'M';
            }
        }
    }
}
