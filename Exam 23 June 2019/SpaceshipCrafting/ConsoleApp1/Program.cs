using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalLiquis = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var physicalItems = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> chemicalItemsQueue = new Queue<int>(chemicalLiquis);
            Stack<int> physicalItemsStack = new Stack<int>(physicalItems);
            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>();

            advancedMaterials.Add("Glass", 0);
            advancedMaterials.Add("Aluminium", 0);
            advancedMaterials.Add("Lithium", 0);
            advancedMaterials.Add("Carbon fiber", 0);

            while (chemicalItemsQueue.Count > 0 && physicalItemsStack.Count > 0)
            {
                int firstChemical = chemicalItemsQueue.Dequeue();
                int firstItem = physicalItemsStack.Pop();
                int result = firstChemical + firstItem;

                if (result == 25)
                {
                    advancedMaterials["Glass"]++;
                }
                else if (result == 50)
                {
                    advancedMaterials["Aluminium"]++;
                }
                else if (result == 75)
                {
                    advancedMaterials["Lithium"]++;
                }
                else if (result == 100)
                {
                    advancedMaterials["Carbon fiber"]++;
                }
                else
                {
                    firstItem += 3;
                    physicalItemsStack.Push(firstItem);
                }
            }

            if (advancedMaterials["Glass"] > 0 && advancedMaterials["Aluminium"] > 0 && advancedMaterials["Lithium"] > 0 && advancedMaterials["Carbon fiber"] > 0) 
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");

                if (chemicalItemsQueue.Count > 0)
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", chemicalItemsQueue)}");
                }

                if (chemicalItemsQueue.Count == 0)
                {
                    Console.WriteLine("Liquids left: none");
                }

                if (physicalItemsStack.Count > 0)
                {
                    Console.WriteLine($"Physical items left: {string.Join(", ", physicalItemsStack)}");
                }
                if (physicalItemsStack.Count == 0)
                {
                    Console.WriteLine("Physical items left: none");
                }
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to build the spaceship.");

                if (chemicalItemsQueue.Count > 0)
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", chemicalItemsQueue)}");
                }

                if (chemicalItemsQueue.Count == 0)
                {
                    Console.WriteLine("Liquids left: none");
                }

                if (physicalItemsStack.Count > 0)
                {
                    Console.WriteLine($"Physical items left: {string.Join(", ", physicalItemsStack)}");
                }
                if (physicalItemsStack.Count == 0)
                {
                    Console.WriteLine("Physical items left: none");
                }
            }

            foreach (var item in advancedMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}