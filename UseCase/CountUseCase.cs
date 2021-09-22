using System.Linq;

namespace DetailResearchOfLinq
{
    public class CountUseCase : BaseUseCase
    {
        public CountUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Count01();
            Count02();
        }

        private void Count01()
        {
            // ユーザ数を数える
            var count = Users.Count();
            LogUtility.Log($"Count: {count}");
        }

        private void Count02()
        {
            // 特定の条件に該当する数を数える
            // int32を超える場合は例外を投げるので、LongCountを使う
            var count = Users.Count(user => user.Age < 20);
            LogUtility.Log($"Count: {count}");
        }
    }
}