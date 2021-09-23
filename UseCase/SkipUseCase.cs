using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SkipUseCase : BaseUseCase
    {
        public SkipUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Skip01();
            Skip02();
            Skip03();
        }

        private void Skip01()
        {
            foreach (var user in Users)
            {
                LogUtility.Log($"user: {user}");
            }
            
            // Idで昇順にソートした上で、最初の3つの要素はスキップしたシーケンスを返す
            var skippedUsers = Users.OrderBy(user => user.Id).Skip(3);
            foreach (var user in skippedUsers)
            {
                LogUtility.Log($"SkippedUser: {user}");
            }
        }

        private void Skip02()
        {
            // countがIEnumerable<T>の要素数を超えている場合は空のシーケンスが返る
            var skippedUsers = Users.Skip(10000);
            foreach (var i in skippedUsers)
            {
                LogUtility.Log($"Empty: {i}");
            }
            LogUtility.Log($"More Skip finished");
        }

        private void Skip03()
        {
            // countが0未満の場合はシーケンス全体がそのまま返る
            var skippedUsers = Users.Skip(-1);
            foreach (var i in skippedUsers)
            {
                LogUtility.Log($"-1.Skip: {i}");
            }
        }
    }
}