namespace _11.PokemonTrainerE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Badges
        {
            get { return this.badges; }
        }

        public List<Pokemon> Pokemons { get { return this.pokemons; } }

        public void AddBadge()
        {
            this.badges++;
        }

        public void RemoveDeadPokemons()
        {
            if (this.pokemons.Count > 0 && this.pokemons.Where(p => p.Health <= 0).FirstOrDefault() != null)
            {
                this.pokemons = new List<Pokemon>(this.pokemons.Where(p => p.Health > 0));
            }
        }

    }
}
