using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            var matrix = new string[r][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] row = Console.ReadLine().Split(", ");
                matrix[i] = row;
            }

            string[] input = Console.ReadLine().Split();
            string command = input[0];
            string header = input[1];
            int headerIndex = Array.IndexOf(matrix[0], header);

            if (command == "hide")
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    List<string> list = new List<string>();
                    list.AddRange(matrix[i].Take(headerIndex).ToList());
                    list.AddRange(matrix[i].Skip(headerIndex + 1));
                    Console.WriteLine(string.Join(" | ", list));
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = matrix[0];
                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                string parameter = input[2];
                string[] headerRow = matrix[0];
                Console.WriteLine(string.Join(" | ", headerRow));
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[i]));
                    }
                }
            }
        }
    }
}
