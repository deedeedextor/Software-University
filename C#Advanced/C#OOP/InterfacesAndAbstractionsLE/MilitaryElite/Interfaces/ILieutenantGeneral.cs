namespace MilitaryElite.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyList<IPrivate> PrivateSoldiers { get; }
    }
}
