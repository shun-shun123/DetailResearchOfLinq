using System.Linq;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.UseCase
{
    public class ThenByDescendingUseCase : BaseUseCase
    {
        public ThenByDescendingUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Users = UserFactory.CreateRandomUserArray(30);
            ThenByDescending01();
        }

        private void ThenByDescending01()
        {
            var users = Users.OrderByDescending(user => user.Age).ThenByDescending(user => user.Id);
            foreach (var user in users)
            {
                LogUtility.Log($"User.OrderByDescending(Age).ThenByDescending(id): {user}");
            }
        }
    }
}