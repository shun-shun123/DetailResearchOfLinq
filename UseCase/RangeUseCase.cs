using System;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class RangeUseCase : BaseUseCase
    {
        public RangeUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Range01();
            Range02();
            Range03();
        }

        private void Range01()
        {
            // start-endまでの連続するシーケンスを作成できる
            var numbers = Enumerable.Range(0, 10);
            foreach (var i in numbers)
            {
                LogUtility.Log($"i: {i}");
            }
        }

        private void Range02()
        {
            try
            {
                // countが0未満の場合は例外を投げる
                var numbers = Enumerable.Range(0, -1);
            }
            catch (Exception ex)
            {
                LogUtility.Log($"startが-1の場合は例外を投げる:{ex.Message}");   
            }
        }

        private void Range03()
        {
            try
            {
                // (start + end- 1) >= int.MaxValueの場合は例外を投げる
                var numbers = Enumerable.Range(2, int.MaxValue);
            }
            catch (Exception ex)
            {
                LogUtility.Log($"(start + end - 1): {(long)(0 + int.MaxValue - 1)}以上なので例外を投げる({ex.Message})");   
            }
        }
    }
}