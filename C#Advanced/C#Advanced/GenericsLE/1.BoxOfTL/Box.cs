namespace BoxOfT
{
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T>
    {
        private List<T> values;

        public int Count { get; }

        public Box()
        {
            this.values = new List<T>();
        }

        public void Add(T value)
        {
            this.values.Add(value);
        }

        public T Remove()
        {
            var lastValue = this.values[this.values.Count - 1];
            this.values.RemoveAt(this.values.Count - 1);
            return lastValue;
        }
    }
}
