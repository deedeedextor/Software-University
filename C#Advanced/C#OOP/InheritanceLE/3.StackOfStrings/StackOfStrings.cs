namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void Pushrange(params string[] data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }
        }

    }
}
