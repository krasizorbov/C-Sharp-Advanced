using System;
using System.Collections.Generic;
namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Remove()
        {
            var item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);

            return item;
        }
    }
}
