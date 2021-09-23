using System.Linq;
using BenchmarkDotNet.Attributes;

namespace DetailResearchOfLinq.Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class FirstOrDefaultBenchmark : BaseBenchmark
    {
        [Benchmark]
        public void PrimitiveArrayImproved()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var target = Rand.Next(0, BenchmarkConfig.DATA_SIZE);
                var _ = NumbersArray.FirstOrDefault(n => n == target);
            }
        }

        [Benchmark]
        public void PrimitiveArray()
        {
            for (var i = 0; i < BenchmarkConfig.TRY_COUNT; i++)
            {
                var target = Rand.Next(0, BenchmarkConfig.DATA_SIZE);
                var _ = Enumerable.FirstOrDefault(NumbersArray, n => n == target);
            }
        }
    }
}