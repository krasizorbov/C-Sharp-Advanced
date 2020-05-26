namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var hallsAndPeople = new Dictionary<string, List<int>>();
            var input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var halls = new Queue<string>();

            while (input.Count > 0)
            {
                var currentChar = input.Peek();

                if (!char.IsDigit(currentChar[0]))
                {

                    hallsAndPeople[currentChar] = new List<int>();
                    halls.Enqueue(currentChar);
                    input.Pop();
                    continue;
                }
                if (hallsAndPeople.Count == 0)
                {
                    input.Pop();
                    continue;
                }

                foreach (var hall in hallsAndPeople)
                {

                    if (hall.Value.Sum() + int.Parse(currentChar) <= capacity)
                    {
                        hallsAndPeople[hall.Key].Add(int.Parse(currentChar));
                        input.Pop();
                        break;
                    }

                    if (hall.Value.Sum() + int.Parse(currentChar) >= capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
                        hallsAndPeople.Remove(hall.Key);
                    }

                    break;
                }
            }
        }
    }
}