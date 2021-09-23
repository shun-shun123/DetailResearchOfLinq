using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class TakeUseCase : BaseUseCase
    {
        public TakeUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Take01();
            Take02();
            Take03();
            Take04();
        }

        private void Take01()
        {
            var numbers = new[] {1, 2, 3, 4, 5};
            // 3つ目は含まれる
            var take = numbers.Take(3);
            foreach (var i in take)
            {
                LogUtility.Log($"i: {i}");
            }
        }

        private void Take02()
        {
            // シーケンスの量を超えるTakeを行うとシーケンス全てがかえる
            var numbers = new[] {1, 2, 3, 4, 5};
            var takeOver = numbers.Take(numbers.Length + 2);
            foreach (var i in takeOver)
            {
                LogUtility.Log($"takeOver: {i}");
            }
        }

        private void Take03()
        {
            // Takeに-1などの負の数を設定すると、空のシーケンスを返す
            var numbers = new[] {1, 2, 3, 4, 5};
            var empty = numbers.Take(-1);
            foreach (var i in empty)
            {
                LogUtility.Log($"empty: {i}");
            }
            LogUtility.Log($"empty finished");
        }

        private void Take04()
        {
            int index = 2;
            var numbers = new[] {1, 2, 3, 4, 5};
            // 同じインデックスへのTakeとSkipはシーケンス全体を意味する
            var take = numbers.Take(index);
            var skip = numbers.Skip(index);
            foreach (var i in take)
            {
                LogUtility.Log($"Take: {i}");
            }

            foreach (var i in skip)
            {
                LogUtility.Log($"Skip: {i}");
            }
        }
    }
}