using BenchmarkDotNet.Running;
using DetailResearchOfLinq.Benchmark;
using DetailResearchOfLinq.Benchmark.Sandbox;
using DetailResearchOfLinq.UseCase;

namespace DetailResearchOfLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            LogUtility.LogLevel = LogUtility.ALL;
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(AggregateBenchmark),
                typeof(AllBenchmark),
                typeof(AnyBenchmark),
                typeof(ContainsBenchmark),
                typeof(CountBenchmark),
                typeof(FirstBenchmark),
                typeof(FirstOrDefaultBenchmark),
                typeof(LinqVsPureLogicBenchmark),
                typeof(SequenceEqualBenchmark),
            });
            switcher.Run(args);
        }

        private static void ExampleUseOfLinq()
        {
            var aggregate = new AggregateUseCase(10);
            aggregate.Execute();

            var all = new AllUseCase(10);
            all.Execute();
            
            var any = new AnyUseCase(10);
            any.Execute();

            var append = new AppendUseCase(10);
            append.Execute();

            var asEnumerable = new AsEnumerableUseCase(10);
            asEnumerable.Execute();

            var average = new AverageUseCase(10);
            average.Execute();

            var cast = new CastUseCase(10);
            cast.Execute();

            var contains = new ContainsUseCase(10);
            contains.Execute();

            var count = new CountUseCase(10);
            count.Execute();

            var defaultIfEmpty = new DefaultIfEmptyUseCase(10);
            defaultIfEmpty.Execute();

            var distinct = new DistinctUseCase(10);
            distinct.Execute();

            var elementAt = new ElementAtUseCase(10);
            elementAt.Execute();

            var elementAtOrDefault = new ElementAtOrDefaultUseCase(10);
            elementAtOrDefault.Execute();

            var empty = new EmptyUseCase(10);
            empty.Execute();

            var except = new ExceptUseCase(10);
            except.Execute();

            var first = new FirstUseCase(10);
            first.Execute();

            var firstOrDefault = new FirstOrDefaultUseCase(10);
            firstOrDefault.Execute();

            var groupBy = new GroupByUseCase(50);
            groupBy.Execute();

            var groupJoin = new GroupJoinUseCase(10);
            groupJoin.Execute();

            var intersect = new IntersectUseCase(10);
            intersect.Execute();

            var join = new JoinUseCase(10);
            join.Execute();

            var last = new LastUseCase(10);
            last.Execute();

            var lastOrDefault = new LastOrDefault(10);
            lastOrDefault.Execute();

            var longCount = new LongCountUseCase(10);
            longCount.Execute();

            var max = new MaxUseCase(10);
            max.Execute();

            var min = new MinUseCase(10);
            min.Execute();

            var ofType = new OfTypeUseCase(10);
            ofType.Execute();

            var orderBy = new OrderByUseCase(10);
            orderBy.Execute();

            var descendingOrderBy = new OrderByDescendingUseCase(10);
            descendingOrderBy.Execute();

            var prepend = new PrependUseCase(10);
            prepend.Execute();

            var range = new RangeUseCase(10);
            range.Execute();

            var repeat = new RepeatUseCase(10);
            repeat.Execute();

            var reverse = new ReverseUseCase(10);
            reverse.Execute();

            var select = new SelectUseCase(10);
            select.Execute();

            var selectMany = new SelectManyUseCase(10);
            selectMany.Execute();

            var sequenceEqual = new SequenceEqualUseCase(10);
            sequenceEqual.Execute();

            var single = new SingleUseCase(10);
            single.Execute();

            var singleOrDefault = new SingleOrDefaultUseCase(10);
            singleOrDefault.Execute();

            var skip = new SkipUseCase(10);
            skip.Execute();

            var skipLast = new SkipLastUseCase(10);
            skipLast.Execute();

            var skipWhile = new SkipWhileUseCase(10);
            skipWhile.Execute();

            var sum = new SumUseCase(10);
            sum.Execute();

            var take = new TakeUseCase(10);
            take.Execute();

            var takeLast = new TakeLastUseCase(10);
            takeLast.Execute();

            var takeWhile = new TakeWhileUseCase(10);
            takeWhile.Execute();

            var thenBy = new ThenByUseCase(10);
            thenBy.Execute();

            var thenByDescending = new ThenByDescendingUseCase(10);
            thenByDescending.Execute();

            var toArray = new ToArrayUseCase(10);
            toArray.Execute();

            var toDictionary = new ToDictionaryUseCase(10);
            toDictionary.Execute();

            var toHashSet = new ToHashSetUseCase(10);
            toHashSet.Execute();

            var toList = new ToListUseCase(10);
            toList.Execute();

            var toLookup = new ToLookupUseCase(10);
            toLookup.Execute();

            var union = new UnionUseCase(10);
            union.Execute();

            var where = new WhereUseCase(10);
            where.Execute();

            var zip = new ZipUseCase(10);
            zip.Execute();
        }
    }
}
