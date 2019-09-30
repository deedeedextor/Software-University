using MXGP.Core.Contracts;
using MXGP.IO;
using System;
using System.Linq;
using System.Reflection;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ConsoleReader reader = new ConsoleReader();
        private ConsoleWriter writer = new ConsoleWriter();

        public Engine()
        {
        }

        IChampionshipController championshipController = new ChampionshipController();

        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" ")
                    .ToArray();

                try
                {
                    string commandName = inputArgs[0];

                    switch (commandName)
                    {
                        case "CreateRider":
                            {
                                string riderName = inputArgs[1];
                                writer.WriteLine(championshipController.CreateRider(riderName));
                            }
                            break;
                        case "CreateMotorcycle":
                            {
                                string type = inputArgs[1];
                                string model = inputArgs[2];
                                int horsePower = int.Parse(inputArgs[3]);

                                writer.WriteLine(championshipController.CreateMotorcycle(type, model, horsePower));
                            }
                            break;
                        case "AddMotorcycleToRider":
                            {
                                string riderName = inputArgs[1];
                                string motorcycleName = inputArgs[2];

                                writer.WriteLine(championshipController.AddMotorcycleToRider(riderName, motorcycleName));
                            }
                            break;
                        case "AddRiderToRace":
                            {
                                string raceName = inputArgs[1];
                                string riderName = inputArgs[2];

                                writer.WriteLine(championshipController.AddRiderToRace(raceName, riderName));
                            }
                            break;
                        case "CreateRace":
                            {
                                string raceName = inputArgs[1];
                                int laps = int.Parse(inputArgs[2]);

                                writer.WriteLine(championshipController.CreateRace(raceName, laps));
                            }
                            break;
                        case "StartRace":
                            {
                                string raceName = inputArgs[1];

                                writer.WriteLine(championshipController.StartRace(raceName));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is TargetInvocationException)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    else
                    {
                        Console.WriteLine(ex.Message);
                    }

                    continue;
                }
                
            }
        }
    }
}
