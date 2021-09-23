using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq
{
    public class EmptyUseCase : BaseUseCase
    {
        public EmptyUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Empty01();
        }

        private void Empty01()
        {
            var firstGroup = Users.TakeWhile(user => user.Id <= 2).ToArray();
            var secondGroup = Users.TakeWhile(user => user.Id <= 4).ToArray();
            var thirdGroup = Users.TakeWhile(user => user.Id <= 5).ToArray();

            var allGroup = new List<User[]>{firstGroup, secondGroup, thirdGroup};

            // Aggregateの初期値としてIEnumerableを渡したい場合に使える
            var allUsers = allGroup.Aggregate(Enumerable.Empty<User>(),
                (current, next) => next.Length > 3 ? current.Union(next) : current);

            foreach (var user in allUsers)
            {
                LogUtility.Log($"user.Name: {user.Name}");
            }
        }
    }
}