using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }

    public class StartUp
    {

    }

    public class Car
    {
        string make;
        string model;
        int year;

        public string Make { get => make; set => make = value;  }

        public string Model { get => model;  set => model = value;  }

        public int Year { get => year;  set => year = value;  }
    }
}
