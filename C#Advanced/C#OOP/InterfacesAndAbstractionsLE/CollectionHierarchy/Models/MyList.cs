namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        private const int IndexToRemove = 0;

        public IReadOnlyCollection<T> Used
        {
            get
            {
                return this.Data as IReadOnlyCollection<T>;
            }
        }

        public override T Remove()
        {
            var firstElement = this.Data.First();
            this.Data.RemoveAt(IndexToRemove);
            return firstElement;
        }
    }
}
