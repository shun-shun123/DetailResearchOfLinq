using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class TakeWhileUseCase : BaseUseCase
    {
        public TakeWhileUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            TakeWhile01();
            TakeWhile02();
        }

        private void TakeWhile01()
        {
            // 5歳以下のユーザの間中取得し続けるシーケンス
            var users = Users.TakeWhile(user => user.Age <= 5);
            foreach (var user in users)
            {
                LogUtility.Log($"User.Age <= 5: {user}");
            }
        }

        private void TakeWhile02()
        {
            // 一つ目からfalseが返るので、空のシーケンスとなる
            var users = Users.TakeWhile(user => false);
            foreach (var user in users)
            {
                LogUtility.Log($"empty.TakeWhile: {user}");
            }
            
            LogUtility.Log($"Empty.TakeWhile finished");
        }
    }
}