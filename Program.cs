using DetailResearchOfLinq.UseCase;

namespace DetailResearchOfLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            LogUtility.LogLevel = LogUtility.ALL;
            
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
        }
    }
}
