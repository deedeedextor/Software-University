using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagedPoints;
        private int healthPoints;

        protected Card(string name, int damagedPoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagedPoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ThrowIfSttringIsNullOrEmpty(value,
                    "Card's name cannot be null or an empty string.");

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagedPoints;
            }
            set
            {
                Validator.ThrowIfNumberIsNegative(value,
                    "Card's damage points cannot be less than zero.");
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                Validator.ThrowIfNumberIsNegative(value,
                    "Card's HP cannot be less than zero.");
            }
        }
    }
}
