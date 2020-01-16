using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionImplementationAndBenchmark
{
    public class Program
    {
        public class EnumerationBenchmark
        {
            private const int _elementsCount = 1000000;

            [Benchmark]
            public void ForEach()
            {
                var elements = CreateElements();
                foreach (var VARIABLE in elements)
                {
                    var a = VARIABLE;
                }
            }

            [Benchmark]
            public void For()
            {
                var elements = CreateElements();
                for (var index = 0; index < _elementsCount; index++)
                {
                    var a = elements[index];
                }
            }

            private List<int> CreateElements()
            {
                var elements = new List<int>();
                var random = new Random();
                for (var index = 0; index < _elementsCount; index++)
                {
                    elements.Add(random.Next(1, 100000));
                }

                return elements;
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Check enumerator implementation (what is called when foreach) and works without IEnumerable implementation just GetEnumerator method definition");
            TestEnumerator();
            BenchmarkRunner.Run(typeof(Program).Assembly, ManualConfig
                .Create(DefaultConfig.Instance)
                .With(ConfigOptions.JoinSummary | ConfigOptions.DisableLogFile));

            Console.WriteLine("Check if to list uses enumerator");
            var enumerable = new TestPossibleMultipleEnumeration();
            var enumerableList = enumerable.GetEnumerable().ToList();

            Console.WriteLine("Show multiple enumeration problem");
            var enumerator = GetRandomEnumerable();
            var list = enumerator.ToList();
            var list2 = enumerator.ToList();

            Console.WriteLine(string.Join(',', list));
            Console.WriteLine(string.Join(",", list2));

            Console.ReadKey();
        }

        public static void TestEnumerator()
        {
            var collectionEnumerator = new TestEnumeratorCollection<int>(CreateElements());

            foreach (var index in collectionEnumerator)
            {
                
            }

            foreach (var VARIABLE in collectionEnumerator)
            {
                var a = VARIABLE;
            }

            foreach (var VARIABLE in collectionEnumerator)
            {
                var a = VARIABLE;
            }
        }

        private static IEnumerable<int> GetRandomEnumerable()
        {
            var random = new Random();

            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
            yield return random.Next(5, 1000000);
        }

        private static int[] CreateElements()
        {
            var random = new Random();
            var elements = new int[random.Next(5,50)];
            
            for (var index = 0; index < elements.Length; index++)
            {
                elements[index] = random.Next(1, 1000000);
            }

            return elements;
        }
    }
}
