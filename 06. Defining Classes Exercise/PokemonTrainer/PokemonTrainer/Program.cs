using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.First(t => t.Name == trainerName);

                trainer.AddPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.ReducePokemonsHealth();
                        trainer.RemoveDead();
                    }
                }
            }

            trainers.OrderByDescending(t => t.Badges).ToList().ForEach(Console.WriteLine);
        }
    }

    public class Trainer
    {
        // Trainers have a name, number of badges and a collection of pokemon
        string name;
        int badges;
        List<Pokemon> pokemons;

        public string Name { get { return name; } set { name = value; } }

        public int Badges { get { return badges; } set { badges = value; } }

        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }

        public Trainer(string trainerName)
        {
            Name = trainerName;
            Pokemons = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void IncreaseBadges()
        {
            Badges++;
        }

        public void ReducePokemonsHealth()
        {
            Pokemons.ForEach(p => p.ReduceHealth());
        }

        public void RemoveDead()
        {
            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }

    public class Pokemon
    {
        //Pokemon have a name, an element and health
        string pokemonName;
        string element;
        int health;

        public string PokemonName { get { return pokemonName; } set { pokemonName = value; } }

        public string Element { get { return element; } set { element = value; } }

        public int Health { get { return health; } set { health = value; } }

        public Pokemon(string pokemonName, string element, int health)
        {
            PokemonName = pokemonName;
            Element = element;
            Health = health;
        }

        public void ReduceHealth()
        {
            Health -= 10;
        }
    }
}
