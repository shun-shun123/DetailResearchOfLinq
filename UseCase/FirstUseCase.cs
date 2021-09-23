using System;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class FirstUseCase : BaseUseCase
    {
        public FirstUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            First01();
            First02();
            First03();
        }

        private void First01()
        {
            // 単純にシーケンスの一番目の要素を取得する
            var first = Users.First();
            LogUtility.Log($"first.User: {first.Name}");
        }

        private void First02()
        {
            // 条件を指定して該当する一番目のものを取得もできる　
            var firstHit = Users.First(user => user.Age > 1);
            LogUtility.Log($"first.hit.User: {firstHit.Name}");
        }

        private void First03()
        {
            try
            {
                // 該当するものがなければ例外を投げる
                var firstHit = Users.First(user => user.Age >= 1000);
            }
            catch (Exception ex)
            {
                LogUtility.Log(ex.Message);
            }
        }
    }
}