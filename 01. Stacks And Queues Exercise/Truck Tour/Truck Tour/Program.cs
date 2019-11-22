using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            var pumpList = new List<int>();
            var stations = new Queue<int>();
            var litrs = new Queue<int>();
            var distances = new Queue<int>();

            int sumL = 0;
            int startingIndex = 0;
            int counter = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                pumpList.Add(i);
                stations.Enqueue(i);

                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int amount = data[0];
                int distance = data[1];

                litrs.Enqueue(amount);
                distances.Enqueue(distance);
            }

            for (int i = 0; i < stations.Count; i++)
            {
                sumL = sumL + litrs.ElementAt(i);
                if (sumL >= distances.ElementAt(i))
                {
                    sumL = sumL - distances.ElementAt(i);
                    startingIndex = stations.Peek();
                    counter++;
                    if (counter == numberOfPumps)
                    {
                        foreach (var pumpIndex in pumpList)
                        {
                            if (startingIndex == pumpIndex)
                            {
                                Console.WriteLine(pumpIndex);
                            }
                        }
                    }
                }
                else
                {
                    stations.Enqueue(stations.Dequeue());
                    litrs.Enqueue(litrs.Dequeue());
                    distances.Enqueue(distances.Dequeue());
                    startingIndex = stations.Peek();
                    counter = 0;
                    sumL = 0;
                    i = - 1;
                }
            }
        }
    }
}
