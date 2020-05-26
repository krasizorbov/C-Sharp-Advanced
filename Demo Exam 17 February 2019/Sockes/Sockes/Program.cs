using System;
using System.Linq;
using System.Collections.Generic;

namespace Sockes
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrLeft = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] arrRight = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> left = new Stack<int>(arrLeft);

            var listLeft = new List<int>(left);

            var listRight = new List<int>(arrRight);

            var listResult = new List<int>();

            while (listLeft.Count > 0 && listRight.Count > 0)
            {
                if (listLeft[0] > listRight[0])
                {
                    int value = listLeft[0] + listRight[0];
                    listResult.Add(value);
                    listLeft.RemoveAt(0);
                    listRight.RemoveAt(0);
                }
                else if (listLeft[0] < listRight[0])
                {
                    listLeft.RemoveAt(0);
                }
                else if (listLeft[0] == listRight[0])
                {
                    listRight.RemoveAt(0);
                    listLeft[0] += 1;
                }
            }
            Console.WriteLine(listResult.Max());
            Console.WriteLine(string.Join(" ", listResult));
        }
    }
}
