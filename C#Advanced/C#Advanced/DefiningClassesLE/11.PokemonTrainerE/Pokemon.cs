using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainerE
{
    public class Pokemon
    {
        private string name;
        private string element;
        private double health;

        public Pokemon(string name, string element, double health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }


        public string Element
        {
            get { return this.element; }
            set { element = value; }
        }


        public double Health
        {
            get { return this.health; }
            set { health = value; }
        }

        public void ReduceHealthPokemons()
        {
            this.health -= 10;
        }
    }
}
