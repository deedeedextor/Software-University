namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Interfaces;
    using System;
    using System.Linq;

    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        private const int IndexToInsert = 0;

        public override int Add(T element)
        {
            this.Data.Insert(IndexToInsert, element);
            return IndexToInsert;
        }

        public virtual T Remove()
        {
            var lastElement = this.Data.Last();
            this.Data.RemoveAt(this.Data.Count - 1);
            return lastElement;
        }
    }
}
