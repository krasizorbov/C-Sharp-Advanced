using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = nums[0];
            int c = nums[1];
            int counter = 0;
            string snake = Console.ReadLine();

            var myQue = new Queue<char>();

            int capacity = r * c;

            for (int i = 0; i < snake.Length; i++)
            {
                myQue.Enqueue(snake[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            var list = myQue.ToList();

            counter = 0;

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                counter++;
                if (counter >= c)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }
        }
    }
}
