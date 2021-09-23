using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq
{
    public class ContainsUseCase : BaseUseCase
    {
        private class UserComparer : IEqualityComparer<User>
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


        public ContainsUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Contains01();
            Contains02();
        }

        private void Contains01()
        {
            var isContain = Users.Contains(new User(0, "", 0));
            LogUtility.Log($"isContain: {isContain}");
        }

        private void Contains02()
        {
            var equalityCompare = Users.Contains(new User(1, "", 0), new UserComparer());
            LogUtility.Log($"equalityCompare: {equalityCompare}");
        }
    }
}