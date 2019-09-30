using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository = new RiderRepository();
        private MotorcycleRepository motorcycleRepository = new MotorcycleRepository();
        private RaceRepository raceRepository = new RaceRepository();

        public ChampionshipController()
        {
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riderRepository.Models.FirstOrDefault(r => r.Name == riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IMotorcycle motorcycle = this.motorcycleRepository.Models.FirstOrDefault(m => m.Model == motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepository.Models.FirstOrDefault(r => r.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRider rider = this.riderRepository.Models.FirstOrDefault(r => r.Name == riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            string fullTypeName = $"{type}Motorcycle";

            if (motorcycleRepository.Models.Any(m => m.Model == model))
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists, model);
            }

            IMotorcycle motorcycle;

            switch (type)
            {
                case "Speed":
                    {
                        motorcycle = new SpeedMotorcycle(model, horsePower);
                    }
                    break;
                default:
                    {
                        motorcycle = new PowerMotorcycle(model, horsePower);
                    }
                    break;
            }

            motorcycleRepository.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, fullTypeName, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.Models.Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (riderRepository.Models.Any(r => r.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);
            riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.Models.FirstOrDefault(r => r.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IRider> orderedRaceRepository = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                orderedRaceRepository[i].WinRace();
            }

            sb.AppendLine($"Rider {orderedRaceRepository[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {orderedRaceRepository[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {orderedRaceRepository[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
