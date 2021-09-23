using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq
{
    public class ExceptUseCase : BaseUseCase
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
        
        public ExceptUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Except01();
            Except02();
        }

        private void Except01()
        {
            var exceptList = new User[]
            {
                new User(0, "User_0", 0),
                new User(2, "User_2", 2),
                new User(4, "User_4", 4),
                new User(6, "User_6", 6),
                new User(8, "User_8", 8),
            };
            // Usersのシーケンスの中で、exceptListに含まれていないものだけを取り出す
            var except = Users.Except(exceptList);
            foreach (var user in except)
            {
                LogUtility.Log($"except.User: {user.Name}");
            }
        }
        
        private void Except02()
        {
            var exceptList = new User[]
            {
                new User(0, "User_0", 0),
                new User(2, "User_2", 2),
                new User(4, "User_4", 4),
                new User(6, "User_6", 6),
                new User(8, "User_8", 8),
            };
            // Usersのシーケンスの中で、exceptListに含まれていないものだけを取り出す
            // IEqualityComparerを渡してEqual判定をカスタマイズすることもできる
            var except = Users.Except(exceptList, new UserComparer());
            foreach (var user in except)
            {
                LogUtility.Log($"except.User: {user.Name}");
            }
        }
    }
}