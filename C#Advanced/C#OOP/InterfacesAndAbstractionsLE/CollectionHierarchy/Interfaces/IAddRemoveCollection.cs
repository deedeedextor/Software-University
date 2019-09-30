namespace CollectionHierarchy.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }

}
