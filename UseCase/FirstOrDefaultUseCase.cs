using System;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class FirstOrDefaultUseCase : BaseUseCase
    {
        public FirstOrDefaultUseCase(int size) : base(size)
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
            var first = Users.FirstOrDefault();
            LogUtility.Log($"first.User: {first?.Name}");

            // 該当するものがなくてもデフォルト値を返す
            // これがあるが故に、返り値はT?になる
            var empty = new User[0];
            var defaultValue = empty.FirstOrDefault();
            LogUtility.Log($"defaultValue: {defaultValue}");
        }

        private void First02()
        {
            // 条件を指定して該当する一番目のものを取得もできる　
            var firstHit = Users.FirstOrDefault(user => user.Age > 1);
            LogUtility.Log($"first.hit.User: {firstHit?.Name}");
        }

        private void First03()
        {
            try
            {
                // 該当するものがなくてもデフォルト値が返るので例外は投げない
                var firstHit = Users.FirstOrDefault(user => user.Age >= 1000);
                LogUtility.Log($"notFound.FirstOrDefault: {firstHit?.Name}");
            }
            catch (Exception ex)
            {
                LogUtility.Log(ex.Message);
            }
        }
    }
}