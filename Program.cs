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
        }
    }
}
