using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SkipWhileUseCase : BaseUseCase
    {
        public SkipWhileUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            SkipWhile01();
            SkipWhile02();
            SkipWhile03();
        }

        private void SkipWhile01()
        {
            // predicateがtrueを返すまで要素をスキップしたシーケンスを返す
            var user3AndMore = Users.SkipWhile(user =>
            {
                LogUtility.LogDetail($"user: {user}");
                return user.Id != 3;
            });
            foreach (var user in user3AndMore)
            {
                LogUtility.Log($"user3AndMore: {user}");
            }
        }

        private void SkipWhile02()
        {
            // 最初の要素の時点でtrueを返さない場合は全てのシーケンスとして返す
            var notSkipped = Users.SkipWhile(user => user.Id == 1000);
            foreach (var user in notSkipped)
            {
                LogUtility.Log($"notSkippedWhile: {user}");
            }
        }

        private void SkipWhile03()
        {
            // 全要素に対してtrueを返し続けるので、空のシーケンスを返す
            var empty = Users.SkipWhile(user => true);
            foreach (var user in empty)
            {
                LogUtility.Log($"empty: {user}");
            }
        }
    }
}