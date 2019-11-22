using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Auto_Repair_And_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine().Split().ToArray();
            var carQue = new Queue<string>(cars);
            var carStack = new Stack<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split("-").ToArray();

                if (data[0] == "Service")
                {
                    if (carQue.Count > 0)
                    {
                        carStack.Push(carQue.Dequeue());
                        string vehicleName = carStack.Peek();
                        Console.WriteLine($"Vehicle {vehicleName} got served.");
                    } 
                }
                else if (data[0] == "CarInfo")
                {
                    string vehicleName = data[1];
                    if (carQue.Contains(vehicleName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (data[0] == "History")
                {
                    var carList = carStack.ToList();
                    Console.WriteLine(string.Join(", ", carList));
                    carList.Clear();
                }
                input = Console.ReadLine();
            }

            if (carQue.Count > 0)
            {
                var waitingVehicles = carQue.ToList();
                Console.WriteLine("Vehicles for service: " + string.Join(", ",waitingVehicles));
            }
            var servedVehicles = carStack.ToList();
            Console.WriteLine("Served vehicles: " + string.Join(", ", servedVehicles));
        }
    }
}
