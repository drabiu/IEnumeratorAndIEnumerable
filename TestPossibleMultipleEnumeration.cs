using System;
using System.Collections.Generic;

namespace CollectionImplementationAndBenchmark
{
    public class TestPossibleMultipleEnumeration
    {
        private const int _elementsCount = 1000000;

        public IEnumerable<int> GetEnumerable()
        {
            return new TestEnumerableCollection<int>(CreateElements());
        }

        public List<int> GetList()
        {
            return CreateListElements();
        }

        private static List<int> CreateListElements()
        {
            var elements = new List<int>();
            var random = new Random();
            for (var index = 0; index < _elementsCount; index++)
            {
                elements.Add(random.Next(1, 100000));
            }

            return elements;
        }

        private static int[] CreateElements()
        {
            var random = new Random();
            var elements = new int[random.Next(5, 50)];

            for (var index = 0; index < elements.Length; index++)
            {
                elements[index] = random.Next(1, 1000000);
            }

            return elements;
        }

    }
}
