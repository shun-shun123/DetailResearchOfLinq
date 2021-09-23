using System;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class LastUseCase : BaseUseCase
    {
        public LastUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Last01();
            Last02();
            Last03();
        }

        private void Last01()
        {
            // 普通に一番最後のやつが帰ってくる
            var last = Users.Last();
            LogUtility.Log($"Last.User: {last}");
        }

        private void Last02()
        {
            // Ageが10以下の最後のユーザが帰ってくる
            var last = Users.Last(user => user.Age <= 10);
            LogUtility.Log($"Last.User.Age <= 10: {last}");
        }

        private void Last03()
        {
            try
            {
                // Firstと同様に見つからない場合は例外を投げる
                var empty = new int[0];
                var last = empty.Last();
            }
            catch (Exception ex)
            {
                LogUtility.Log($"empty.Last: {ex.Message}");
            }
        }
    }
}