namespace CollectionHierarchy.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAddCollection<T>
    {
        int Add(T element);
    }
}
