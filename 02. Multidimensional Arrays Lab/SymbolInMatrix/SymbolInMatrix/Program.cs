using System;
using System.Linq;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var arr = new char[num, num];

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < num; j++)
                {
                    arr[i, j] = input[j];
                }
            }

            char output = char.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (arr[i,j] == output)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{output} does not occur in the matrix");
        }
    }
}
