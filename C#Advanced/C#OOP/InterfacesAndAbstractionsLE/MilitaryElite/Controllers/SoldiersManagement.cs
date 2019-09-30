namespace MilitaryElite.Controllers
{
    using MilitaryElite.Interfaces;
    using MilitaryElite.Missions;
    using MilitaryElite.Repairs;
    using MilitaryElite.Soldiers.Privates;
    using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers;
    using MilitaryElite.Soldiers.Spies;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoldiersManagement
    {
        private List<ISoldier> soldiers;
        private List<IPrivate> privates;

        public SoldiersManagement()
        {
            this.soldiers = new List<ISoldier>();
            this.privates = new List<IPrivate>();
        }

        internal string RegisterPrivate(string id, string firstName, string lastName, decimal salary)
        {
            var currentPrivate = new Private(id, firstName, lastName, salary);
            this.privates.Add(currentPrivate);

            return currentPrivate.ToString();
        }

        internal string RegisterLeutenantGeneral(string id, string firstName, string lastName, decimal salary, IEnumerable<string> privatesIds)
        {
            var lethenantGeneralsPrivates = new List<IPrivate>();

            foreach (var privateId in privatesIds)
            {
                var currentPrivate = this.privates.FirstOrDefault(p => p.Id == privateId);

                if (currentPrivate != null)
                {
                    lethenantGeneralsPrivates.Add(currentPrivate);
                }
            }

            var currentSoldier = new LieutenantGeneral(id, firstName, lastName, salary, lethenantGeneralsPrivates);
            this.soldiers.Add(currentSoldier);

            return currentSoldier.ToString();
        }

        internal string RegisterEngineer(string id, string firstName, string lastName, decimal salary, string corps, string[] repairsData)
        {
            var repairs = new Queue<IRepair>();

            for (int i = 0; i < repairsData.Length; i++)
            {
                var partName = repairsData[i];
                i++;
                var hoursWorked = int.Parse(repairsData[i]);

                repairs.Enqueue(new Repair(partName, hoursWorked));
            }

            var currentSoldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            this.soldiers.Add(currentSoldier);

            return currentSoldier.ToString();
        }

        internal string RegisterCommando(string id, string firstName, string lastName, decimal salary, string corps, string[] missionsData)
        {
            var missions = new Queue<IMission>();

            for (int i = 0; i < missionsData.Length; i++)
            {
                var codeName = missionsData[i];
                i++;
                var state = missionsData[i];

                try
                {
                    missions.Enqueue(new Mission(codeName, state));
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            var currentSoldier = new Commando(id, firstName, lastName, salary, corps, missions);
            this.soldiers.Add(currentSoldier);

            return currentSoldier.ToString();
        }

        internal string RegisterSpy(string id, string firstName, string lastName, int codeNumber)
        {
            var currentSoldier = new Spy(id, firstName, lastName, codeNumber);
            this.soldiers.Add(currentSoldier);

            return currentSoldier.ToString();
        }
    }
}
