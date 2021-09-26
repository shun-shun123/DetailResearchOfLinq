using System.Linq;
using BenchmarkDotNet.Attributes;

namespace DetailResearchOfLinq.Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class CountBenchmark : BaseBenchmark
    {
        [Benchmark]
        public void PrimitiveArrayImproved()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = NumbersArray.Count(j => j % 2 == 0);
            }
        }

        [Benchmark]
        public void PrimitiveArray()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = Enumerable.Count(NumbersArray, j => j % 2 == 0);
            }
        }

        [Benchmark]
        public void PrimitiveListImproved()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = NumbersList.Count(j => j % 2 == 0);
            }
        }

        [Benchmark]
        public void PrimitiveList()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = Enumerable.Count(NumbersList, j => j % 2 == 0);
            }
        }

        [Benchmark]
        public void PrimitiveDictionaryImproved()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = NumbersDict.Count(j => j.Value % 2 == 0);
            }
        }

        [Benchmark]
        public void PrimitiveDictionary()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var count = Enumerable.Count(NumbersDict, j => j.Value % 2 == 0);
            }
        }
    }
}