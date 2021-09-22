using System.Linq;

namespace DetailResearchOfLinq
{
    public class AggregateUseCase : BaseUseCase
    {
        public AggregateUseCase(int size) : base(size)
        {
        }
        
        public override void Execute()
        {
            base.Execute();
            Aggregate01();
            Aggregate02();
            Aggregate03();
            
        }

        private void Aggregate01()
        {
            var average = Users.Select(user => user.Age)
                .Aggregate(0,
                    (accumulate, elem) =>
                    {
                        // ここで年齢の合計を計算する
                        LogUtility.LogDetail($"(accumulate, elem): ({accumulate}, {elem}");
                        return accumulate + elem;
                    }, (accumulate) =>
                    {
                        // ここで平均を算出する
                        LogUtility.LogDetail($"accumulate: {accumulate}");
                        return accumulate / Users.Length;
                    });
            LogUtility.Log($"average: {average}");
        }

        private void Aggregate02()
        {
            // 初期値を設定した上で、Aggregateすることができる
            var totalAge = Users.Select(user => user.Age)
                .Aggregate(10,
                    (accumulate, elem) =>
                    {
                        LogUtility.LogDetail($"(accumulate, elem): ({accumulate}, {elem}");
                        return accumulate + elem;
                    });
            LogUtility.Log($"aggregate with initValue: {totalAge}");
        }

        private void Aggregate03()
        {
            // シンプルなAccumulate
            var totalAge = Users.Select(user => user.Age)
                .Aggregate((accumulate, elem) =>
                {
                    LogUtility.LogDetail($"(accumulate, elem): ({accumulate}, {elem}");
                    return accumulate + elem;
                });
            LogUtility.Log($"totalAge: {totalAge}");
        }
    }
}
