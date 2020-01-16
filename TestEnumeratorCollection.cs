using System;
using System.Collections.Generic;

namespace CollectionImplementationAndBenchmark
{
    public class TestEnumeratorCollection<T> : IEnumerator<T>
    {
        protected T[] _elements;
        private int _index = -1;
        private T _current;

        public TestEnumeratorCollection(T[] elements)
        {
            _elements = elements;

            Console.WriteLine($"Collection initialized with {elements.Length} elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("Generic GetEnumerator Called");

            return new TestEnumeratorCollection<T>(_elements);
        }

        public bool MoveNext()
        {
            Console.WriteLine("MoveNext Called");
            _index++;
            if (_index >= _elements.Length)
            {
                return false;
            }

            _current = _elements[_index];

            return true;
        }

        public void Reset()
        {
            Console.WriteLine("Reset Called");
            _index = -1;
            _current = _elements[0];
        }

        T IEnumerator<T>.Current
        {
            get
            {
                Console.WriteLine("Generic Current Called");

                return _current;
            }
        }

        public object Current
        {
            get
            {
                Console.WriteLine("Current Called");

                return _elements[_index];
            }
        }

        public void Dispose()
        {
        }
    }
}