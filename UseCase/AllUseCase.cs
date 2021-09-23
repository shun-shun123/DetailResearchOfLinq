using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class AllUseCase : BaseUseCase
    {
        public AllUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            All01();
        }

        private void All01()
        {
            // 全要素に対してpredicateを実行する
            var young = Users.All(user =>
            {
                LogUtility.LogDetail("Users.All Success");
                return user.Age <= 22;
            });
            
            LogUtility.Log($"Young: {young}");
            
            // Allは一度falseが返った時点で処理は終了する
            var _ = Users.All(user =>
            {
                LogUtility.LogDetail("Users.All Failed");
                return user.Age < 0;
            });

            // All, Anyの挙動の違いは空のシーケンスに対して処理を行った場合に現れる
            // Allの場合は空のシーケンスでもtrueを返す
            int[] empty = new int[0];
            var flag = empty.All(num => num % 2 == 0);
            LogUtility.Log($"empty.All: {flag}");
        }
    }
}