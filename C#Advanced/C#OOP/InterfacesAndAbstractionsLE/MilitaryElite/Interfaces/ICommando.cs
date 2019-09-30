namespace MilitaryElite.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyList<IMission> Missions { get; }
    }
}
