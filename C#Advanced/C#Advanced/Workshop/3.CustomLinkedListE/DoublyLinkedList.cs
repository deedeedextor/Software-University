namespace CustomLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class DoublyLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class ListNode
        {
            public T Value { get; set; }

            public ListNode NextNote { get; set; }

            public ListNode PreviousNote { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }

            else
            {
                var newHead = new ListNode(element);
                newHead.NextNote = this.head;
                this.head.PreviousNote = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }

            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNote = this.tail;
                this.tail.NextNote = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNote;

            if (this.head != null)
            {
                this.head.PreviousNote = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNote;

            if (this.tail != null)
            {
                this.tail.NextNote = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public bool Contains(T value)
        {
            var currentNode = this.head;
        
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return true;
                }
        
                currentNode = currentNode.NextNote;
            }
        
            return false;
        }
        
        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNote;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int counter = 0;
            var currentNode = this.head;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNote;
                counter++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextNote;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
