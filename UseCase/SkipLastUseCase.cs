using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SkipLastUseCase : BaseUseCase
    {
        public SkipLastUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            SkipLast01();
            SkipLast02();
            SkipLast03();
        }

        private void SkipLast01()
        {
            foreach (var user in Users)
            {
                LogUtility.Log($"User: {user}");
            }
            var skipLastUsers = Users.SkipLast(3);
            foreach (var user in skipLastUsers)
            {
                LogUtility.Log($"SkipLastUser: {user}");
            }
        }

        private void SkipLast02()
        {
            // スキップ数が要素数を超える場合は空のシーケンスが返る
            var skipOverUsers = Users.SkipLast(1000);
            foreach (var user in skipOverUsers)
            {
                LogUtility.Log($"SkipOverUser: {user}");
            }
            
            LogUtility.Log($"SkipOver finished");
        }

        private void SkipLast03()
        {
            // スキップ数が負の場合は全てのシーケンスが返る
            var allSequence = Users.SkipLast(-3);
            foreach (var user in allSequence)
            {
                LogUtility.Log($"Skip-3: {user}");
            }
        }
    }
}