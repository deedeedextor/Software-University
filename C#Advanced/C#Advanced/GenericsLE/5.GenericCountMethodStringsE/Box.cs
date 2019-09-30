namespace _5.GenericCountMethodStringsE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private T value { get; }

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(T element)
        {
            return this.value.CompareTo(element);
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {this.value}";
        }
    }
}
