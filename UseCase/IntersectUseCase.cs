using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.UseCase
{
    public class IntersectUseCase : BaseUseCase
    {
        private sealed class UserEqualityComparer : IEqualityComparer<User>
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

        private User[] randomUsers;
        
        public IntersectUseCase(int size) : base(size)
        {
            randomUsers = UserFactory.CreateRandomUserArray(size);
        }

        public override void Execute()
        {
            base.Execute();
            Intersect01();
            Intersect02();
            Intersect03();
        }

        private void Intersect01()
        {
            // TODO: どういう方法で等価判定されているのか
            var num1 = new int[] {0, 2, 4, 6, 8, 10};
            var num2 = new int[] {2, 4, 8, 16};
            var intersect = num1.Intersect(num2);
            foreach (var i in intersect)
            {
                LogUtility.Log($"i: {i}");
            }
        }

        private void Intersect02()
        {
            var intersect = randomUsers.Intersect(Users);
            foreach (var user in intersect)
            {
                LogUtility.Log($"user: {user.Id}, {user.Name}, {user.Age}");
            }
        }

        private void Intersect03()
        {
            // EqualityComparerを設定することもできる
            var intersect = randomUsers.Intersect(Users, new UserEqualityComparer());
            foreach (var user in intersect)
            {
                LogUtility.Log($"Equality.User: {user.Id}, {user.Name}, {user.Age}");
            }
        }
    }
}