using System;
using System.Collections.Generic;
using System.Text;


namespace CustomStructure
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;
        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }
        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public T RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var item = this.items[index];
            this.items[index] = default(T);
            this.Shift(index);
            this.Count--;
            if (this.Count <= items.Length / 4)
            {
                this.Shrink();
            }
            return item;
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void InsertAt(int index, T element)
        {
            CheckIdexRange(index);
            ShiftToRight(index);
            this.items[index] = element;
            Count++;
        }
        private void CheckIdexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}

