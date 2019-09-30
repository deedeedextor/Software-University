namespace MilitaryElite.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyList<IRepair> Repairs { get; }
    }
}
