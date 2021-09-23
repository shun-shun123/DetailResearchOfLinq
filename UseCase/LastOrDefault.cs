using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class LastOrDefault : BaseUseCase
    {
        public LastOrDefault(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            LastOrDefault01();
            LastOrDefault02();
            LastOrDefault03();
        }

        private void LastOrDefault01()
        {
            // Default値が返ってくる場合もあるので、nullable
            var lastOrDefault = Users.LastOrDefault();
            LogUtility.Log($"LastOrDefault.User: {lastOrDefault}");
        }

        private void LastOrDefault02()
        {
            var lastOrDefault = Users.LastOrDefault(user => user.Age >= 5);
            LogUtility.Log($"LastOrDefault.User.Age >= 5: {lastOrDefault}");
        }

        private void LastOrDefault03()
        {
            // 空のシーケンスに対しては、デフォルト値がかえる
            var defaultValue = (new User[0]).LastOrDefault();
            LogUtility.Log($"Empty.User.LastOrDefault: {defaultValue?.Name}");

            // int型の場合はデフォルト値0がかえる
            var emptyNumber = (new int[0]).LastOrDefault();
            LogUtility.Log($"empty.Number.LastOrDefault: {emptyNumber}");
        }
    }
}