using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class TakeLastUseCase : BaseUseCase
    {
        public TakeLastUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            TakeLast01();
            TakeLast02();
            TakeLast03();
        }

        private void TakeLast01()
        {
            foreach (var user in Users)
            {
                LogUtility.Log($"AllUser: {user}");
            }

            // 最後から二つだけ要素を取り出すシーケンスを作成する
            var takeLast = Users.TakeLast(2);
            foreach (var user in takeLast)
            {
                LogUtility.Log($"LastTwo: {user}");
            }
        }

        private void TakeLast02()
        {
            // 要素数以上の数をTakeLastしようとすると、シーケンスがそのまま返る
            var takeOver = Users.TakeLast(1000);
            foreach (var user in takeOver)
            {
                LogUtility.Log($"takeOver {user}");
            }
        }

        private void TakeLast03()
        {
            // 負の数でTakeLastしようとすると、空のシーケンスが返る
            var negativeTake = Users.TakeLast(-2);
            foreach (var user in negativeTake)
            {
                LogUtility.Log($"negativeTake: {user}");
            }
        }
    }
}