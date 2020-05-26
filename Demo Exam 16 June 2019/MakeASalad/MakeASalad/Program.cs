using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vegetables = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            Queue<string> veg = new Queue<string>(vegetables);

            int[] calories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> cal = new Stack<int>(calories);

            Queue<int> salads = new Queue<int>();

            while (veg.Count > 0 && cal.Count > 0)
            {
                var currentCalories = cal.Peek();

                while (currentCalories > 0 && veg.Count > 0)
                {
                    var currentVeg = veg.Dequeue();

                    if (currentVeg == "tomato")
                    {
                        currentCalories -= 80;
                    }
                    else if (currentVeg == "carrot")
                    {
                        currentCalories -= 136;
                    }
                    else if (currentVeg == "lettuce")
                    {
                        currentCalories -= 109;
                    }
                    else if (currentVeg == "potato")
                    {
                        currentCalories -= 215;
                    }
                }

                salads.Enqueue(cal.Pop());
            }
            if (salads.Any())
            {
                Console.WriteLine(string.Join(" ", salads));
            }

            if (veg.Any())
            {
                Console.WriteLine(string.Join(" ", veg));
            }

            else if (cal.Any())
            {
                Console.WriteLine(string.Join(" ", cal));
            }
        }
    }
}