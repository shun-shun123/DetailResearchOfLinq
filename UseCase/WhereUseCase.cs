using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class WhereUseCase : BaseUseCase
    {
        public WhereUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Where01();
            Where02();
        }

        private void Where01()
        {
            var evenIdUsers = Users.Where(user => user.Id % 2 == 0);
            foreach (var user in evenIdUsers)
            {
                LogUtility.Log($"EvenIdUser: {user}");
            }
        }

        private void Where02()
        {
            var evenIdUserWithIndex = Users.Where((user, index) => user.Id % 2 == 0 && index <= 5);
            foreach (var user in evenIdUserWithIndex)
            {
                LogUtility.Log($"EvenIdUser(index <= 5): {user}");
            }
        }
    }
}