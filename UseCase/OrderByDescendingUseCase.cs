using System;
using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.UseCase
{
    public class OrderByDescendingUseCase : BaseUseCase
    {
        private sealed class AgeOrderBy : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;

                if (x.Age == y.Age)
                {
                    return 0;
                }

                if (x.Age < y.Age)
                {
                    return -1;
                }

                if (x.Age > y.Age)
                {
                    return 1;
                }
                var idComparison = x.Id.CompareTo(y.Id);
                if (idComparison != 0) return idComparison;
                var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                if (nameComparison != 0) return nameComparison;
                return x.Age.CompareTo(y.Age);
            }
        }
        
        public OrderByDescendingUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            OrderByDescending01();
            OrderByDescending02();
        }

        private void OrderByDescending01()
        {
            var users = UserFactory.CreateRandomUserArray(Users.Length);
            // 返り値はIOrderedEnumerable<TSource>となっており、これはThenByやThenByDescendingに繋げられるように
            // IOrderedEnumerable<T>もIEnumerable<T>を実装しているので、結果的に最後に呼ばれたOrderByでソートされる（らしい）
            // TODO: 要チェック
            var descendingSortedUsers = users.OrderByDescending(user =>
            {
                LogUtility.LogDetail($"users.OrderBy.keySelector: {user}");
                return user.Id;
            });
            foreach (var user in descendingSortedUsers)
            {
                LogUtility.Log($"User: {user}");
            }
        }

        private void OrderByDescending02()
        {
            var users = UserFactory.CreateRandomUserArray(Users.Length);
            // User型に定義したIComparerを使えば、Userを渡すだけで年齢順にソートしてくれる
            var descendingSortedUsers = users.OrderByDescending(user => user, new AgeOrderBy());
            foreach (var user in descendingSortedUsers)
            {
                LogUtility.Log($"AscendingSortedUserByAge: {user}");
            }
        }
    }
}