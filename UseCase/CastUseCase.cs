using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class CastUseCase : BaseUseCase
    {
        public CastUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Cast01();
        }

        private void Cast01()
        {
            // UserをObjectにキャストしたシーケンスを返す
            var objects = Users.Cast<object>();
            foreach (var user in objects)
            {
                LogUtility.Log($"user.GetType: {user.GetType()}");
            }
        }
    }
}