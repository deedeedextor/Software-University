using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (planet.Items.Count != 0)
            {
                var astronaut = astronauts
                    .FirstOrDefault(a => a.CanBreath);

                if (astronaut == null)
                {
                    break;
                }

                var item = planet.Items.First();

                if (item == null)
                {
                    break;
                }

                astronaut.Breath();

                astronaut.Bag.Items.Add(item);

                planet.Items.Remove(item);

                if (!astronaut.CanBreath)
                {
                    continue;
                }
            }
        }
    }
}
