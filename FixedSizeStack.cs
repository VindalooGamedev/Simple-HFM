using System;
using System.Collections;
using System.Collections.Generic;

namespace StateMachinesLab
{
    public class FixedSizeStack<T> : IEnumerable<T>, IReadOnlyCollection<T>, ICollection, IEnumerable
    {
        private T[] _items;
        private int _count;

        public FixedSizeStack(int size)
        {
            _items = new T[size];
            _count = 0;
        }

        public int Count => _count;

        public bool IsSynchronized => false;
        public object SyncRoot { get; } = new object();

        public T Peek() => _items[_count];
        public void Push(T item)
        {
            _count++;
            _items[_count] = item;
        }

        public T Pop()
        {
            _count--;
            return _items[_count +1];
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException();
            if (Count + index >= array.Length - 1) throw new ArgumentException();
            int elementsToCopy = _items.Length - index;
            for (int i = 0; i < elementsToCopy; i++)
                array.SetValue(_items[i], index + i);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _items.Length; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
