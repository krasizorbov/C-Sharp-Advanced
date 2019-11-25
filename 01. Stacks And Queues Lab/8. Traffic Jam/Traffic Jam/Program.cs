using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            var myQ = new Queue<string>();

            int counter = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    if (numberOfCars <= myQ.Count)
                    {
                        for (int i = 0; i < numberOfCars; i++)
                        {
                            string passedCar = myQ.Dequeue();
                            Console.WriteLine($"{passedCar} passed!");
                            counter++;
                        }
                    }
                    else
                    {
                        while (myQ.Count > 0)
                        {
                            string passedCar = myQ.Dequeue();
                            Console.WriteLine($"{passedCar} passed!");
                            counter++;
                        } 
                    }
                }
                else
                {
                    myQ.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
