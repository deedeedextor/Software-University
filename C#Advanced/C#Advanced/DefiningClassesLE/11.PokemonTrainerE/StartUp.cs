using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainerE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = GetTrainers();

            CheskElementsAndHealth(trainers);

            PrintTrainers(trainers);
        }

        private static void PrintTrainers(List<Trainer> trainers)
        {
            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(t => t.Badges)
                .Select(t => $"{t.Name} {t.Badges} {t.Pokemons.Count}")));
        }

        private static void CheskElementsAndHealth(List<Trainer> trainers)
        {
            string element = string.Empty;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Where(p => p.Element == element).FirstOrDefault() == null)
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.ReduceHealthPokemons();
                        }

                        trainer.RemoveDeadPokemons();
                    }

                    else
                    {
                        trainer.AddBadge();
                    }
                }
            }
        }

        private static List<Trainer> GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemon = tokens[1];
                string pokemonElement = tokens[2];
                double pokemonHealth = double.Parse(tokens[3]);

                var currentPokemon = new Pokemon(pokemon, pokemonElement, pokemonHealth);
                var currentTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();

                if (currentTrainer == null)
                {
                    currentTrainer = new Trainer(trainerName);
                    currentTrainer.Pokemons.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                }

                else
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                }
            }

            return trainers;
        }
    }
}
