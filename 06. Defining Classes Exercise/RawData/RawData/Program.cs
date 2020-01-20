using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            //<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>

            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];

                List<Tire> tires = new List<Tire>();

                for (int j = 5; j < input.Length; j+=2)
                {
                    double pressure = double.Parse(input[j]);

                    int age = int.Parse(input[j + 1]);

                    tires.Add(new Tire(pressure, age));
                }

                Engine engine = new Engine(speed, power);

                Cargo cargo = new Cargo(weight, type);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).Select(c => c.Model).ToList().ForEach(Console.WriteLine);
            }
            else if (command == "flamable")
            {
                cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).Select(x => x.Model).ToList().ForEach(Console.WriteLine);
            }
        }
    }

    public class Car
    {
        string model;
        Engine engine;
        Cargo cargo;
        List<Tire> tires;
        public string Model { get { return model; } set { model = value; } }

        public Engine Engine { get { return engine; } set { engine = value; } }

        public Cargo Cargo { get { return cargo; } set { cargo = value; } }

        public List<Tire> Tires { get { return tires; } set { tires = value; } }
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
    }

    public class Engine
    {
        int speed;
        int power;

        public int Speed { get { return speed; } set { speed = value; } }

        public int Power { get { return power; } set { power = value; } }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    public class Cargo
    {
        int weight;
        string type;

        public int Weight { get { return weight; } set { weight = value; } }

        public string Type { get { return type; } set { type = value; } }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

    public class Tire
    {
        double pressure;
        int age;

        public double Pressure { get { return pressure; } set { pressure = value; } }

        public int Age { get { return age; } set { age = value; } }

        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}
