using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            var arr = new int[r][];

            for (int i = 0; i < arr.Length; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arr[i] = new int[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    arr[i][j] = input[j];
                }
            }

            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "END")
            {
                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int toSum = int.Parse(command[3]);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        for (int j = 0; j < arr[i].Length; j++)
                        {
                            if (row >= 0 && row < arr.Length && col >= 0 && col < arr[i].Length)
                            {
                                if (row == i && col == j)
                                {
                                    arr[row][col] += toSum;
                                }  
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                                goto label;
                            }
                        }
                    }
                }
                else if (command[0] == "Subtract")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int toSubtract = int.Parse(command[3]);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        for (int j = 0; j < arr[i].Length; j++)
                        {
                            if (row >= 0 && row < arr.Length && col >= 0 && col < arr[i].Length)
                            {
                                if (row == i && col == j)
                                {
                                    arr[row][col] -= toSubtract;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                                goto label;
                            }
                        }
                    }
                }
                label:
                command = Console.ReadLine().Split().ToArray();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
