using CarManufacturer;
using System;
using System.Collections.Generic;

namespace Special_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tiresArray = new List<string>();
            List<string> engineArray = new List<string>();
            List<string> carArray = new List<string>();

            string tiresInput = Console.ReadLine();

            while (tiresInput != "No more tires")
            {
                tiresArray.Add(tiresInput);

                tiresInput = Console.ReadLine();
            }

            string engineInput = Console.ReadLine();

            while (engineInput != "Engines done")
            {
                engineArray.Add(engineInput);

                engineInput = Console.ReadLine();
            }

            string carInput = Console.ReadLine();

            while (carInput != "Show special")
            {
                carArray.Add(carInput);

                carInput = Console.ReadLine();
            }

            var carOutput = new List<string>();

            for (int i = 0; i < carArray.Count; i++)
            {
                string[] c = carArray[i].Split();

                string make = c[0];
                string model = c[1];
                int year = int.Parse(c[2]);
                double fuelQuantity = double.Parse(c[3]);
                double fuelConsumption = double.Parse(c[4]);
                int engineIndex = int.Parse(c[5]);
                int tireIndex = int.Parse(c[6]);

                string[] e = engineArray[engineIndex].Split();

                var engine = new Engine(int.Parse(e[0]), double.Parse(e[1]));

                double sum = 0;

                string[] t = tiresArray[tireIndex].Split();

                sum = double.Parse(t[1]) + double.Parse(t[3]) + double.Parse(t[5]) + double.Parse(t[7]);

                var tires = new Tire[4]
                {
                    new Tire(int.Parse(t[0]), double.Parse(t[1])),
                    new Tire(int.Parse(t[2]), double.Parse(t[3])),
                    new Tire(int.Parse(t[4]), double.Parse(t[5])),
                    new Tire(int.Parse(t[6]), double.Parse(t[7])),
                };

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                if (year >= 2017 && engine.HorsePower > 330 && sum > 9 && sum < 10)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;
        Engine engine;
        Tire tire;
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire Tire { get; set; }

        public void Drive(double distance)
        {
            double currenFuelQuantity = distance * FuelConsumption / 100;

            if (FuelQuantity - currenFuelQuantity > 0)
            {
                FuelQuantity -= currenFuelQuantity;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tire = tire;
        }
    }

    public class Engine
    {
        int horsePower;
        double cubicCapacity;

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        int year;
        double pressure;

        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
