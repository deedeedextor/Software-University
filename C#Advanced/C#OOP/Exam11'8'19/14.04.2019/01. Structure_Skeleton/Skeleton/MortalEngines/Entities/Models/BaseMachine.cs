using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private readonly IList<string> targets;

        private BaseMachine()
        {
            this.targets = new List<string>();
        }

        public BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
            : this()
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defencePoints;
            HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }

        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double valueToDecrease = Math.Abs(this.AttackPoints - target.DefensePoints);

            target.HealthPoints -= valueToDecrease;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            var information = new StringBuilder();

            //string targetsOutput = this.targets.Count > 0 ?
                //string.Join(",", targets) : "None";

            information.AppendLine($"- {this.Name}")
                       .AppendLine($" *Type: {this.GetType().Name}")
                       .AppendLine($" *Health: {this.HealthPoints:F2}")
                       .AppendLine($" *Attack: {this.AttackPoints:F2}")
                       .AppendLine($" *Defense: {this.DefensePoints:F2}");
                       //.AppendLine($" *Targets: {targetsOutput}");

            if (Targets.Count != 0)
            {
                information.AppendLine($" *Targets: {string.Join(",", targets)}");
            }

            else
            {
                information.AppendLine(" *Targets: None");
            }

            return information.ToString().TrimEnd();
        }
    }
}
