using System;
using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class SequenceEqualUseCase : BaseUseCase
    {
        private sealed class UserEqualityComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                // 名前が同じなら同一とみなす
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name;
            }

            public int GetHashCode(User obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Age);
            }
        }
        
        public SequenceEqualUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            SequenceEqual01();
            SequenceEqual02();
            SequenceEqual03();
        }

        private void SequenceEqual01()
        {
            // DefaultEqualityComparerによって、等値判定される
            var equal = Users.SequenceEqual(Users);
            LogUtility.Log($"IsSequenceEqual: {equal}");
        }

        private void SequenceEqual02()
        {
            var numbers1 = new[] {1, 2, 3};
            var numbers2 = new[] {1, 2};
            // 長さが異なる場合は違うと判定される
            var equal = numbers1.SequenceEqual(numbers2);
            LogUtility.Log($"DiffLength: {equal}");
        }

        private void SequenceEqual03()
        {
            var users1 = new[]
            {
                new User(0L, "User_0", 0),
                new User(1L, "User_0", 1),
                new User(2L, "User_0", 2),
            };
            var users2 = new[]
            {
                new User(0L, "User_0", 0),
                new User(11L, "User_0", 11),
                new User(22L, "User_0", 22),
            };

            // これはデフォルトのEqualityComparerが使われるため、異なると判定される
            var equal = users1.SequenceEqual(users2);
            LogUtility.Log($"normalEqual: {equal}");

            // これはカスタマイズされたEqualityComparerが使用されるため、一致すると判定される
            // こんな感じで等値判定にはIEqualityComparerを実装しているものを渡すことができる
            var customEqual = users1.SequenceEqual(users2, new UserEqualityComparer());
            LogUtility.Log($"CustomEqual: {customEqual}");
        }
    }
}