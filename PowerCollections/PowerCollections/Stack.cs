using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;

        private int count;

        public int Capacity { get; }
        public int Count
        {
            get { return count; }
        }
        public Stack(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Param bad format.Stack size must not be less than or equal to 0");
            }
            Capacity = size;
            items = new T[size];
        }

        public bool IsEmpty {
            get { return count == 0; } 
        }

        public void Push (T item)
        {
            if (count == items.Length)
            {
                throw new InvalidOperationException("Overflow stack");
            }
            items[count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[--count];
        }

        public T Top()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {

            if (IsEmpty)
            {
                yield break;
            }
            for (int i = count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
                
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
