using CarManufacturer;
using System;

namespace Car_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();

            Console.WriteLine(firstCar.Make);
            Console.WriteLine(firstCar.Model);
            Console.WriteLine(firstCar.Year);
            Console.WriteLine(firstCar.FuelQuantity);
            Console.WriteLine(firstCar.FuelConsumption);

            Car secondCar = new Car(make, model, year);

            Console.WriteLine(secondCar.Make);
            Console.WriteLine(secondCar.Model);
            Console.WriteLine(secondCar.Year);
            Console.WriteLine(secondCar.FuelQuantity);
            Console.WriteLine(secondCar.FuelConsumption);

            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Console.WriteLine(thirdCar.Make);
            Console.WriteLine(thirdCar.Model);
            Console.WriteLine(thirdCar.Year);
            Console.WriteLine(thirdCar.FuelQuantity);
            Console.WriteLine(thirdCar.FuelConsumption);
        }
    }
}
namespace CarManufacturer
{
    public class StartUp
    {

    }

    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;
        public string Make { get => make; set => make = value; }

        public string Model { get => model; set => model = value; }

        public int Year { get => year; set => year = value; }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }

        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }


        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year):this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption):this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
    }
}
