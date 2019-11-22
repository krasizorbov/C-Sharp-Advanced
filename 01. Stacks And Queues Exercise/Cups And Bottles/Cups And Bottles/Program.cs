using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_And_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cupsQue = new Queue<int>(cups);
            var bottlesStack = new Stack<int>(bottles);
            int wastedWater = 0;
            int difference = 0;

            while (bottlesStack.Count > 0 && cupsQue.Count > 0)
            {
                if (bottlesStack.Peek() >= cupsQue.Peek())
                {
                    wastedWater += (bottlesStack.Pop() - cupsQue.Dequeue());
                }
                else
                {
                    difference = cupsQue.Peek() - bottlesStack.Peek();
                    bottlesStack.Pop();
                    cupsQue.Dequeue();

                    if (bottlesStack.Peek() >= difference)
                    {
                        wastedWater += (bottlesStack.Pop() - difference);
                    }
                    else
                    {
                        while (difference > bottlesStack.Peek())
                        {
                            difference = difference - bottlesStack.Pop();
                        }

                        wastedWater += (bottlesStack.Pop() - difference);
                    }
                }

                difference = 0;
            }
            if (bottlesStack.Count > 0)
            {
                var bottlesList = bottlesStack.ToList();
                Console.WriteLine($"Bottles: " + string.Join(" ", bottlesList));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            if (bottlesStack.Count == 0)
            {
                var cupsList = cupsQue.ToList();
                Console.WriteLine($"Cups: " + string.Join(" ", cupsList));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
