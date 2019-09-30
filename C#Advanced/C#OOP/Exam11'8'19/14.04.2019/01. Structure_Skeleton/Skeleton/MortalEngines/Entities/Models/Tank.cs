using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defencePoints) 
            : base(name, attackPoints, defencePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string defensiveOutput = this.DefenseMode ?
                "ON" : "OFF";

            return base.ToString() + 
                Environment.NewLine + 
                $" *Defense: {defensiveOutput}";
        }
    }
}
