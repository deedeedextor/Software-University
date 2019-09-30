﻿using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Animals
{

    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happiness = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }
        public string Owner { get; set; } = "Centre";
        public bool IsAdopt { get; set; }
        public bool IsChipped { get; set; }
        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return $"    Animal type: {this.GetType()} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
