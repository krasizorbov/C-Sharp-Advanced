using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numEngines; i++)
            {
                //<Model> <Power> <Displacement> <Efficiency> 
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                int power = int.Parse(input[1]);

                if (input.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (input.Length == 3)
                {
                    if (input[2].All(char.IsDigit))
                    {
                        int displacement = int.Parse(input[2]);
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = input[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                //<Model> <Engine> <Weight> <Color>
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                Engine engine = engines.First(x => x.Model == input[1]);

                if (input.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (input.Length == 3)
                {
                    if (input[2].All(char.IsDigit))
                    {
                        int weight = int.Parse(input[2]);
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = input[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            cars.ForEach(Console.WriteLine);
        }
    }

    public class Car
    {
        string model;
        int weight;    //optional
        string color;   //optional
        Engine engine;

        public string Model { get { return model; } set { model = value; } }

        public int Weight { get { return weight; } set { weight = value; } }

        public string Color { get { return color; } set { color = value; } }

        public Engine Engine { get { return engine; } set { engine = value; } }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{Model}:");
            builder.Append(Engine);
            builder.AppendLine($"  Weight: {(Weight == 0 ? "n/a" : Weight.ToString())}");
            builder.Append($"  Color: {(Color == null ? "n/a" : Color)}");

            return builder.ToString();
        }
    }

    public class Engine
    {
        string model;
        int power;
        int displacement;   //optional
        string efficiency;  //optional

        public int Power { get { return power; } set { power = value; } }

        public int Displacement { get { return displacement; } set { displacement = value; } }

        public string Efficiency { get { return efficiency; } set { efficiency = value; } }

        public string Model { get { return model; } set { model = value; } }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
        {
            Model = model;
            Power = power;
            Efficiency = efficiency;
        }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"  {Model}:");
            builder.AppendLine($"    Power: {Power}");
            builder.AppendLine($"    Displacement: {(Displacement == 0 ? "n/a" : Displacement.ToString())}");
            builder.AppendLine($"    Efficiency: {(Efficiency == null ? "n/a" : Efficiency.ToString())}");

            return builder.ToString();
        }
    }
}
