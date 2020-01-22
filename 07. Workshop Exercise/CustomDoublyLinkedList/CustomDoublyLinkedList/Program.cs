using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddLast("string");
            doublyLinkedList.AddLast("123456");
            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class DoublyLinkedList<T> : INumerable<T>
        where T:IComparable<T>
    {
        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; }
        private class ListNode
        {
            public T Value { get; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode(T value)
            {
                Value = value;
            }
        }
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T firstElement = head.Value;
            head = head.NextNode;
            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return firstElement;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T lastElement = tail.Value;
            tail = tail.PreviousNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return lastElement;
        }
        public void ForEach(Action<T> action)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public bool Containes(T value)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            var currentNode = head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }
            return array;
        }
        public List<T> ToList()
        {
            List<T> list = new List<T>(Count);
            var currentNode = head;
            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            return list;
        }
        private void CheckIfEmptyThrowException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("BoublyLinkedList is empty!");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            ListNode currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }
        //IEnumerator INumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}
    }

    public interface INumerable<T> where T : IComparable<T>
    {
    }
}
