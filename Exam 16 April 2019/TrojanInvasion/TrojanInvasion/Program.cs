using System;
using System.Linq;
using System.Collections.Generic;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            int[] plates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int plateToAdd = 0;

            var platesQue = new List<int>(plates);

            var warriorsStack = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                if (i % 3 == 0)
                {
                    int[] warriors = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    for (int j = 0; j < warriors.Length; j++)
                    {
                        warriorsStack.Push(warriors[j]);
                    }
                    plateToAdd = int.Parse(Console.ReadLine());
                    platesQue.Add(plateToAdd);
                }
                else
                {
                    int[] warriors = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    for (int j = 0; j < warriors.Length; j++)
                    {
                        warriorsStack.Push(warriors[j]);
                    }
                }

                var warriorsList = warriorsStack.ToList();

                warriorsStack.Clear();

                while (platesQue.Count > 0 && warriorsList.Count > 0)
                {
                    if (platesQue[0] > warriorsList[0])
                    {
                        platesQue[0] = platesQue[0] - warriorsList[0];
                        warriorsList.RemoveAt(0);
                    }
                    else if (platesQue[0] < warriorsList[0])
                    {
                        warriorsList[0] = warriorsList[0] - platesQue[0];
                        platesQue.RemoveAt(0);
                    }
                    else if (platesQue[0] == warriorsList[0])
                    {
                        platesQue.RemoveAt(0);
                        warriorsList.RemoveAt(0);
                    }
                }

                if (platesQue.Count == 0 && warriorsList.Count > 0)
                {
                    Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine($"Warriors left: {string.Join(", ", warriorsList)}");
                    break;
                }
                else if (warriorsList.Count == 0 && platesQue.Count > 0 && i == waves)
                {
                    Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                    Console.WriteLine($"Plates left: {string.Join(", ", platesQue)}");
                    break;
                }
            } //  for ends here 
        }
    }
}
