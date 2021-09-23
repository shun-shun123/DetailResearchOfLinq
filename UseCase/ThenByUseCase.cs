using System.Linq;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.UseCase
{
    public class ThenByUseCase : BaseUseCase
    {
        public ThenByUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Users = UserFactory.CreateRandomUserArray(Users.Length);
            ThenBy01();
        }

        private void ThenBy01()
        {
            // ThenByはIOrderedEnumerable<TSource>に対する拡張メソッド
            // OrderByやOrderByDescendingの返り値に対してメソッドチェーンできる
            // もちろんIComparerを渡すオーバーロードもあるが、OrderByとかと変わらないので割愛
            var users = Users.OrderBy(user => user.Age).ThenBy(user => user.Id);
            foreach (var user in users)
            {
                LogUtility.Log($"Users.OrderBy.ThenBy: {user}");
            }
        }
    }
}