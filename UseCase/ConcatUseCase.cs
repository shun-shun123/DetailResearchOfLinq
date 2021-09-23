using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ConcatUseCase : BaseUseCase
    {
        public ConcatUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Concat01();
        }

        private void Concat01()
        {
            // 二つのシーケンスを連結する
            var doubleUsers = Users.Concat(Users);
            foreach (var user in doubleUsers)
            {
                LogUtility.Log($"user: {user.Name}");
            }
        }
    }
}