using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public abstract class BaseBenchmark
    {
        protected int[] NumbersArray;

        protected List<int> NumbersList;

        protected Dictionary<int, int> NumbersDict;

        protected Random Rand;
        
        [GlobalSetup]
        public void Setup()
        {
            NumbersArray = PrimitiveDataFactory.CreateNumberSequenceByArray(BenchmarkConfig.DATA_SIZE);

            NumbersList = PrimitiveDataFactory.CreateNumberSequenceByArray(BenchmarkConfig.DATA_SIZE).ToList();

            NumbersDict = PrimitiveDataFactory.CreateNumberSequenceByArray(BenchmarkConfig.DATA_SIZE)
                .ToDictionary(number => number,
                    number => number);

            Rand = new Random();
        }
    }
}