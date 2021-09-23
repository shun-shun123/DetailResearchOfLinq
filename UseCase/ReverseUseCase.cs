using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ReverseUseCase : BaseUseCase
    {
        public ReverseUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Reverse01();
        }

        private void Reverse01()
        {
            foreach (var user in Users)
            {
                LogUtility.Log($"user: {user}");
            }

            // 単純に逆むきのシーケンスを作成する
            var reverse = Users.Reverse();
            foreach (var user in reverse)
            {
                LogUtility.Log($"reverse.User: {user}");
            }
        }
    }
}