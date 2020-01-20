using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                cars.Add(new Car(input[0], double.Parse(input[1]), double.Parse(input[2])));
            }

            string driveCar = Console.ReadLine();

            while (driveCar != "End")
            {
                var data = driveCar.Split().ToArray();

                string model = data[1];
                int distance = int.Parse(data[2]);

                Car car = cars.First(c => c.Model == model);

                car.Drive(model, distance);

                driveCar = Console.ReadLine();
            }

            cars.ForEach(Console.WriteLine);
        }
    }

    class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumption;
        int distanceTravelled;

        public string Model { get { return model; } set { model = value; } }

        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }

        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public int Distance { get { return distanceTravelled; } set { distanceTravelled = value; } }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = 0;
        }

        public void Drive(string name, int distance)
        {
            double currentFuel = FuelConsumption * distance;

            if (FuelAmount >= currentFuel)
            {
                FuelAmount -= currentFuel;
                distanceTravelled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {distanceTravelled}";
        }
    }
}
