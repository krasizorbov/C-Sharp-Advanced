using System;
using System.Collections.Generic;
using System.Text;


namespace CustomStructure
{
    public class CustomStack<T>
    {
        private const int initialCapacity = 4;
        private T[] items;
        private int count;
        public CustomStack()
        {
            this.count = 0;
            this.items = new T[initialCapacity];
        }
        public int Count { get => this.count; }
        public void Push(T element)
        {
            if (this.items.Length == this.count)
            {
                var nextItems = new T[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    nextItems[i] = this.items[i];
                }
                this.items = nextItems;
            }
            this.items[this.count] = element;
            count++;
        }
        public T Pop()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            var lastIndex = this.count - 1;
            T last = this.items[lastIndex];
            this.count--;
            return last;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
