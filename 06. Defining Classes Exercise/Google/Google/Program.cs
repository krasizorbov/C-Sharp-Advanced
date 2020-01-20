﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                string property = input[1];

                if (!people.Any(p => p.Name == name))
                {
                    people.Add(new Person(name));
                }

                var current = people.First(p => p.Name == name);

                switch (property)
                {
                    case "company":
                        current.AssignCompany(input[2], input[3], decimal.Parse(input[4]));
                        break;
                    case "pokemon":
                        current.AddPokemon(input[2], input[3]);
                        break;
                    case "parents":
                        string parentName = input[2];
                        current.AddParent(new Person(parentName, input[3]));
                        break;
                    case "children":
                        string childName = input[2];
                        current.AddChild(new Person(childName, input[3]));
                        break;
                    case "car":
                        current.AssignCar(input[2], int.Parse(input[3]));
                        break;
                    default:
                        throw new Exception();
                }
            }

            command = Console.ReadLine();

            Person result = people.First(p => p.Name == command);

            Console.WriteLine(result);
        }
    }

public class Person
    {
        private class Company
        {
            private string name;
            private string department;
            private decimal salary;

            public Company(string name, string department, decimal salary)
            {
                this.name = name;
                this.department = department;
                this.salary = salary;
            }

            public override string ToString()
            {
                return $"{name} {department} {salary:F2}";

            }
        }

        private class Pokemon
        {
            private string name;
            private string type;

            public Pokemon(string name, string type)
            {
                this.name = name;
                this.type = type;
            }

            public override string ToString()
            {
                return $"{name} {type}";
            }
        }

        private class Car
        {
            private string model;
            private int speed;

            public Car(string model, int speed)
            {
                this.model = model;
                this.speed = speed;
            }

            public override string ToString()
            {
                return $"{model} {speed}";
            }
        }

        private string name;
        private List<Person> parents;
        private List<Person> children;
        private List<Pokemon> pokemons;
        private Car car;
        private Company company;
        string birthday;

        public Person(string name, string birthday = null)
        {
            this.name = name;
            this.birthday = birthday;
            this.parents = new List<Person>();
            this.children = new List<Person>();
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public void AddParent(Person parent)
        {
            parents.Add(parent);
        }

        public void AddChild(Person child)
        {
            children.Add(child);
        }

        public void AddPokemon(string pokemonName, string pokemonType)
        {
            pokemons.Add(new Pokemon(pokemonName, pokemonType));
        }

        public void AssignCompany(string companyName, string department, decimal salary)
        {
            company = new Company(companyName, department, salary);
        }

        public void AssignCar(string model, int speed)
        {
            car = new Car(model, speed);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.name);
            builder.AppendLine("Company:");

            if (company != null)
            {
                builder.AppendLine(company.ToString());
            }

            builder.AppendLine("Car:");

            if (car != null)
            {
                builder.AppendLine(car.ToString());
            }

            builder.AppendLine("Pokemon:");

            foreach (var pokemon in pokemons)
            {
                builder.AppendLine(pokemon.ToString());
            }

            builder.AppendLine("Parents:");

            foreach (var parent in parents)
            {
                builder.AppendLine($"{parent.name} {parent.birthday}");
            }

            builder.AppendLine("Children:");

            foreach (var child in children)
            {
                builder.AppendLine($"{child.name} {child.birthday}");
            }

            return builder.ToString();
        }
    }
}
