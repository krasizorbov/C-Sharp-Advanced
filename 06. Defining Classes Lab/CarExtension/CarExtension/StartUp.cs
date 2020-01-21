
using System;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 15;

            car.Drive(200);
            Console.WriteLine(car.WhoAmI());
        }
    }


    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;

        public string Make { get { return make; } set { make = value; } }

        public string Model { get { return model; } set { model = value; } }

        public int Year { get { return year; } set { year = value; } }

        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public void Drive(double distance)
        {
            double currenFuelQuantity = distance * FuelConsumption / 100;

            if (FuelQuantity - currenFuelQuantity >= 0)
            {
                FuelQuantity -= currenFuelQuantity;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var carInfo = new StringBuilder();

            carInfo.AppendLine($"Make: {this.Make}");

            carInfo.AppendLine($"Model: {this.Model}");

            carInfo.AppendLine($"Year: {this.Year}");

            carInfo.Append($"Fuel: {this.FuelQuantity:F2}L");

            return carInfo.ToString();
        }
    }
}


    

