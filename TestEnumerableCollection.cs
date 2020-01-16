using System.Collections;
using System.Collections.Generic;

namespace CollectionImplementationAndBenchmark
{
    public class TestEnumerableCollection<T> : TestEnumeratorCollection<T>, IEnumerable<T>
    {
        public TestEnumerableCollection(T[] elements) : base(elements)
        {
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}