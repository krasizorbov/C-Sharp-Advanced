using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            // Read input and fill-up the matrix
            int[,] matrix = SetUpMatrix();

            // Read & Apply commands
            string command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                int[] commandTokens = command
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = commandTokens[0]; // [-2^31 + 1, 2^31 - 1]
                int col = commandTokens[1]; // [-2^31 + 1, 2^31 - 1]
                int radius = commandTokens[2];  // [0, 2^31 - 1]

                // Mark the destroyed cells with 0 as values in the matrix start from 1
                // mark center
                if (Validate(matrix, row, col))
                {
                    matrix[row, col] = 0;
                }

                // mark to the left
                int currentCol = col - 1;
                for (int i = 0; i < radius; i++)
                {
                    if (Validate(matrix, row, currentCol))
                    {
                        matrix[row, currentCol] = 0;
                    }
                    currentCol--;
                }

                // mark to the right
                currentCol = col + 1;
                for (int i = 0; i < radius; i++)
                {
                    if (Validate(matrix, row, currentCol))
                    {
                        matrix[row, currentCol] = 0;
                    }
                    currentCol++;
                }

                // mark up
                int currentRow = row - 1;
                for (int i = 0; i < radius; i++)
                {
                    if (Validate(matrix, currentRow, col))
                    {
                        matrix[currentRow, col] = 0;
                    }
                    currentRow--;
                }

                // mark down
                currentRow = row + 1;
                for (int i = 0; i < radius; i++)
                {
                    if (Validate(matrix, currentRow, col))
                    {
                        matrix[currentRow, col] = 0;
                    }
                    currentRow++;
                }

                // Remove marked cells
                matrix = RemoveEmptyCells(matrix);

                // Run Garbage Collector to reduce used memory for taking test 10
                GC.Collect();

                command = Console.ReadLine();
            }

            // Print the remains from the initial matrix
            Print(matrix);
        }

        private static int[,] RemoveEmptyCells(int[,] matrix)
        {
            // push empty cols to the end
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Queue<int> currentRow = new Queue<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        currentRow.Enqueue(matrix[i, j]);
                    }
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (currentRow.Count > 0)
                    {
                        matrix[i, j] = currentRow.Dequeue();
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            // check for empty rows and remove them
            List<int> emptyRowsIndexes = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // if you find non-empty element go to next row
                    if (matrix[i, j] != 0)
                    {
                        break;
                    }

                    // if that's the last element and it's 0, then the row is empty, save the index
                    if (j == matrix.GetLength(1) - 1 && matrix[i, j] == 0)
                    {
                        emptyRowsIndexes.Add(i);
                    }
                }
            }

            if (emptyRowsIndexes.Count == 0)
            {
                return matrix;
            }
            else
            {
                int reducedMatrixrows = matrix.GetLength(0) - emptyRowsIndexes.Count;
                int reducedMatrixCols = matrix.GetLength(1);
                int[,] reducedMatrix = new int[reducedMatrixrows, reducedMatrixCols];

                int reducedMatrixRow = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (emptyRowsIndexes.Contains(i))
                    {
                        continue;
                    }

                    int reducedMatrixCol = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        reducedMatrix[reducedMatrixRow, reducedMatrixCol] = matrix[i, j];
                        reducedMatrixCol++;
                    }

                    reducedMatrixRow++;
                }

                return reducedMatrix;
            }
        }

        private static bool Validate(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static int[,] SetUpMatrix()
        {
            int[] dimensions = Console.ReadLine()
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            int cellValue = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cellValue;
                    cellValue++;
                }
            }

            return matrix;
        }

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}