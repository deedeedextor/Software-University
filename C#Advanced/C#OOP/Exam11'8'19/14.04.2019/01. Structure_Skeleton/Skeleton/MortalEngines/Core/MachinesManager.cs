namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            string result = string.Empty;

            bool isHired = this.pilots.Any(p => p.Name == name);

            if (!isHired)
            {
                IPilot pilot = new Pilot(name);
                this.pilots.Add(pilot);

                result = string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;

            bool isManufactured = this.machines.Any(t => t.Name == name && t.GetType().Name == nameof(Tank));

            if (!isManufactured)
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                result = $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
            }
            else
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;

            bool isManufactured = this.machines.Any(f => f.Name == name && f.GetType().Name == nameof(Fighter));

            if (!isManufactured)
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);

                result = $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
            }
            else
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilotToFind = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            IMachine machineToFind = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilotToFind == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machineToFind == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machineToFind.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, machineToFind.Name);
            }

            else
            {
                pilotToFind.AddMachine(machineToFind);
                machineToFind.Pilot = pilotToFind;

                return string.Format(OutputMessages.MachineEngaged, pilotToFind.Name, machineToFind.Name);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine defender = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defender == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attacker.Name);
            }

            if (defender.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defender.Name);
            }

            attacker.Attack(defender);

            return string.Format(OutputMessages.AttackSuccessful,
                defender.Name,
                attacker.Name,
                defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot foundPilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return foundPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine foundMachine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return foundMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string result = string.Empty;

            IMachine fighter = this.machines.FirstOrDefault(f => f.Name == fighterName && f.GetType().Name == nameof(Fighter));

            if (fighter != null)
            {
                IFighter currentFighter = (IFighter)fighter;
                currentFighter.ToggleAggressiveMode();

                result = string.Format(OutputMessages.FighterOperationSuccessful, currentFighter.Name); 
            }

            else
            {
                result = string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            string result = string.Empty;

            IMachine tank = this.machines.FirstOrDefault(f => f.Name == tankName && f.GetType().Name == nameof(Tank));

            if (tank != null)
            {
                ITank currentTank = (ITank)tank;
                currentTank.ToggleDefenseMode();

                result = string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                result = string.Format(OutputMessages.MachineNotFound, tankName);
            }

            return result;
        }
    }
}