using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class AnyUseCase : BaseUseCase
    {
        public AnyUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Any01();
            Any02();
        }

        private void Any01()
        {
            // 引数なしのAnyは一つでも要素があるかをチェックする
            var any = Users.Any();
            LogUtility.Log($"Has.any: {any}");

            // 空の場合はfalseが返る
            var empty = new int[0];
            LogUtility.Log($"Empty.Any: {empty.Any()}");
        }

        private void Any02()
        {
            var any = Users.Any(user =>
            {
                // 該当するものが見つかるまで操作し続ける
                LogUtility.LogDetail($"user.Age: {user.Age}");
                return user.Age == 15;
            });
            LogUtility.Log($"any: {any}");
        }
    }
}