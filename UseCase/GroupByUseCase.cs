using System.Linq;
using DetailResearchOfLinq.Data;
using Microsoft.VisualBasic;

namespace DetailResearchOfLinq
{
    public class GroupByUseCase : BaseUseCase
    {
        public GroupByUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Users = UserFactory.CreateRandomUserArray(Users.Length);
            GroupBy01();
            GroupBy02();
        }

        private void GroupBy01()
        {
            // Func<TSource, TKey> KeySelector: IEnumerable<T>のTからどれをキーとして取り出すか
            // Func<TSource, TElement> elementSelector: Groupingする要素をどのように取り出すか
            // Func<TKey, IEnumerable<TElement>, TResult> resultSelector: 結果をどのようなグループ形式で取得するか
            // IEqualityComparer<TKey> comparer
            // って感じで使える
            var groups = Users.GroupBy(user => user.Age,
                user => user.Name,
                (key, collection) =>
                {
                    // このresultSelectorは一つ一つグループ化が完了した後に実行されていってるっぽい
                    var members = collection as string[] ?? collection.ToArray();
                    LogUtility.LogDetail($"resultSelector(count: {members.Length})");
                    return new
                    {
                        Age = key,
                        Names = members,
                        Count = members.Count()
                    };
                });
            foreach (var group in groups)
            {
                LogUtility.Log($"Age: {group.Age}, Names: {group.Names}, Count: {group.Count}");
            }
        }

        private void GroupBy02()
        {
            // resultSelectorとかないやつも使える
            var groups = Users.GroupBy(user => user.Age,
                user => user);
            foreach (IGrouping<int, User> group in groups)
            {
                LogUtility.LogDetail($"Age: {group.Key}");
                foreach (var users in group)
                {
                    
                    LogUtility.LogDetail($"\tName: {users.Name}");
                }
            }
        }
    }
}