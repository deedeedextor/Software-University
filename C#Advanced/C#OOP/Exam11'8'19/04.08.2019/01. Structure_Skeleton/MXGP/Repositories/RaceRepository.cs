﻿using MXGP.Models.Races.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
