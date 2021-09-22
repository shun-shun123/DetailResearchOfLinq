using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq
{
    public class DistinctUseCase : BaseUseCase
    {
        public class UserComparer : IEqualityComparer<User>
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
        
        public DistinctUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Distinct01();
            Distinct02();
        }

        private void Distinct01()
        {
            var doubleUsers = Users.Concat(Users);
            foreach (var user in doubleUsers)
            {
                LogUtility.LogDetail($"doubleUser: {user.Name}");
            }

            var distinct = doubleUsers.Distinct();
            foreach (var user in distinct)
            {
                LogUtility.LogDetail($"distinct: {user.Name}");
            }
        }

        private void Distinct02()
        {
            // EqualityCompareを渡してDistinctもできる
            var doubleUsers = Users.Concat(Users);
            var distinct = doubleUsers.Distinct(new UserComparer());
            foreach (var user in distinct)
            {
                LogUtility.LogDetail($"distinct.EqualityCompare: {user.Name}");
            }
        }
    }
}