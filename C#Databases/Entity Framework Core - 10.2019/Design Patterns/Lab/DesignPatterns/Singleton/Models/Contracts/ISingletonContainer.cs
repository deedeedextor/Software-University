using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Models.Contracts
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
