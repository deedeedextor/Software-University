using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautsRepository;
        private IRepository<IPlanet> planetsRepository;
        private IMission mission;

        public Controller()
        {
            this.astronautsRepository = new AstronautRepository();
            this.planetsRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        int exploredPlanets = 0;

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            IAstronaut astronaut = null;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }

            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }

            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            this.astronautsRepository.Add(astronaut);

            return $"Successfully added {astronaut.GetType().Name}: {astronaut.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            this.planetsRepository.Add(planet);

            return $"Successfully added Planet: {planet.Name}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetsRepository.FindByName(planetName);

            var suitableAstronauts = this.astronautsRepository
                .Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            this.mission.Explore(planet, suitableAstronauts);
            exploredPlanets++;

            return $"Planet: {planet.Name} was explored! Exploration finished with {suitableAstronauts.Where(a => a.Oxygen == 0).Count()} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            var outputInfo = string.Empty;

            foreach (var astronaut in this.astronautsRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                outputInfo = astronaut.Bag.Items.Count != 0
                    ? string.Join(", ", astronaut.Bag.Items)
                    : "none";

                sb.AppendLine($"Bag items: {outputInfo}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronautToRetire = this.astronautsRepository.FindByName(astronautName);

            if (astronautToRetire == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautsRepository.Remove(astronautToRetire);

            return $"Astronaut {astronautToRetire.Name} was retired!";
        }
    }
}
