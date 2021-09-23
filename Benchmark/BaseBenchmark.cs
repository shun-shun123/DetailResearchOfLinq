using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using DetailResearchOfLinq.Data;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public abstract class BaseBenchmark
    {
        protected int[] NumbersArray;

        protected User[] UsersArray;

        protected List<int> NumbersList;

        protected List<User> UsersList;

        protected Random Rand;
        
        [GlobalSetup]
        public void Setup()
        {
            NumbersArray = PrimitiveDataFactory.CreateNumberSequenceByArray(BenchmarkConfig.DATA_SIZE);
            UsersArray = UserFactory.CreateUserArray(BenchmarkConfig.DATA_SIZE);

            NumbersList = PrimitiveDataFactory.CreateNumberSequenceByArray(BenchmarkConfig.DATA_SIZE).ToList();
            UsersList = UserFactory.CreateRandomUserArray(BenchmarkConfig.DATA_SIZE).ToList();

            Rand = new Random();
        }
    }
}