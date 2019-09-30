namespace CollectionHierarchy.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        IReadOnlyCollection<T> Used { get; }
    }
}
