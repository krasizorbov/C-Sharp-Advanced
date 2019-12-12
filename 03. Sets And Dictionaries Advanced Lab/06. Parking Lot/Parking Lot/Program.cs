using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            var myHash = new HashSet<string>();

            while (input[0] != "END")
            {
                string direction = input[0];
                string plateNumber = input[1];

                if (direction == "IN")
                {
                    myHash.Add(plateNumber);
                }
                else if(direction == "OUT")
                {
                    myHash.Remove(plateNumber);
                }

                input = Console.ReadLine().Split(", ").ToArray();
            }
            if (myHash.Count > 0)
            {
                foreach (var item in myHash)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
