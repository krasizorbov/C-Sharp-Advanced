using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();

            ////Console.WriteLine(firstCar.Make);
            ////Console.WriteLine(firstCar.Model);
            ////Console.WriteLine(firstCar.Year);
            ////Console.WriteLine(firstCar.FuelQuantity);
            ////Console.WriteLine(firstCar.FuelConsumption);

            //Car secondCar = new Car(make, model, year);

            ////Console.WriteLine(secondCar.Make);
            ////Console.WriteLine(secondCar.Model);
            ////Console.WriteLine(secondCar.Year);
            ////Console.WriteLine(secondCar.FuelQuantity);
            ////Console.WriteLine(secondCar.FuelConsumption);

            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            ////Console.WriteLine(thirdCar.Make);
            ////Console.WriteLine(thirdCar.Model);
            ////Console.WriteLine(thirdCar.Year);
            ////Console.WriteLine(thirdCar.FuelQuantity);
            ////Console.WriteLine(thirdCar.FuelConsumption);

            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6300);

            var fourthCar = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            ////Console.WriteLine(fourthCar.Make);
            ////Console.WriteLine(fourthCar.Model);
            ////Console.WriteLine(fourthCar.Year);
            ////Console.WriteLine(fourthCar.FuelQuantity);
            ////Console.WriteLine(fourthCar.FuelConsumption);
            ////Console.WriteLine(fourthCar.Engine.HorsePower);
            ////Console.WriteLine(fourthCar.Engine.CubicCapacity);
            ////foreach (var tire in tires)
            ////{
            ////    Console.WriteLine(tire.Year);
            ////    Console.WriteLine(tire.Pressure);
            ////}
        }
    }
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;
        Engine engine;
        Tire[] tires;

        public string Make { get { return make; } set { make = value; } }

        public string Model { get { return model; } set { model = value; } }

        public int Year { get { return year; } set { year = value; } }

        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public Engine Engine { get { return engine; } set { engine = value; } }

        public Tire[] Tires { get { return tires; } set { tires = value; } }

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
            this.Tires = tires;
        }
    }

    public class Engine
    {
        int horsePower;
        double cubicCapacity;

        public int HorsePower { get { return horsePower; } set { horsePower = value; } }

        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }

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

        public int Year { get { return year; } set { year = value; } }

        public double Pressure { get { return pressure; } set { pressure = value; } }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
