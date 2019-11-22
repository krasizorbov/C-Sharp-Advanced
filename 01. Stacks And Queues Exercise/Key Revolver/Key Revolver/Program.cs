using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletsCounter = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();
                intelligenceValue -= bulletPrice;

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (++bulletsCounter == barrelSize && bullets.Count > 0)
                {
                    bulletsCounter = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
        }
    }
}
