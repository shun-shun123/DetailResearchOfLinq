using System;
using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class UnionUseCase : BaseUseCase
    {
        private sealed class UserIdComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(User obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        private sealed class UserAgeComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Age == y.Age;
            }

            public int GetHashCode(User obj)
            {
                return obj.Age;
            }
        }
        
        public UnionUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Union01();
            Union02();
        }

        private void Union01()
        {
            // 和集合を取る。重複する箇所は一つの要素になる
            // IEqualityComparerを渡すことで、和の取り方をカスタムすることもできる
            var numbers1 = Enumerable.Range(0, 20).Where(i => i % 2 == 0);
            var numbers2 = Enumerable.Range(0, 20).Where(i => i % 5 == 0);
            
            foreach (var i in numbers1)
            {
                LogUtility.LogDetail($"numbers1: {i}");
            }

            foreach (var i in numbers2)
            {
                LogUtility.LogDetail($"numbers2: {i}");
            }

            var union = numbers1.Union(numbers2);
            foreach (var i in union)
            {
                LogUtility.Log($"union: {i}");
            }
        }

        private void Union02()
        {
            var users1 = new User[]
            {
                new User(1, "User_1", 1),
                new User(2, "User_2", 2),
                new User(3, "User_3", 3),
            };

            var users2 = new User[]
            {
                new User(1, "User_Sub_1", 10),
                new User(2, "User_Sub_1", 20),
                new User(3, "User_Sub_1", 30),
            };

            // IEqualityComparerを実装したものを渡せば、Unionの結果も変わる
            var idUnion = users1.Union(users2, new UserIdComparer());
            var ageUnion = users1.Union(users2, new UserAgeComparer());

            foreach (var user in idUnion)
            {
                LogUtility.Log($"id.Union: {user}");
            }

            foreach (var user in ageUnion)
            {
                LogUtility.Log($"age.Union: {user}");
            }
        }
    }
}