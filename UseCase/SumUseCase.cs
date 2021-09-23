using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SumUseCase : BaseUseCase
    {
        public SumUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Sum01();
            Sum02();
        }

        private void Sum01()
        {
            // 数値のIEnumerable<T>に対してSumを実行すると、合計値が算出できる
            var numbers = Enumerable.Range(0, 10);
            var sum = numbers.Sum();
            LogUtility.Log($"0..10 sum: {sum}");
        }

        private void Sum02()
        {
            // こんな感じで、数値じゃないものを返そうとするオーバーロードは定義されていない
            // var usersSum = Users.Sum(user => user);
            
            // 数値に対してのSumはできるのでこんなことはできる
            var totalAge = Users.Sum(user => user.Age);
            LogUtility.Log($"totalAge: {totalAge}");
        }
    }
}