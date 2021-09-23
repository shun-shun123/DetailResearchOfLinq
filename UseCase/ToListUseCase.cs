using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ToListUseCase : BaseUseCase
    {
        public ToListUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ToList01();
        }

        private void ToList01()
        {
            // ToListが呼ばれた時点で、即時実行される
            var userList = Users.Where(user => user.Id % 2 == 0).ToList();
            foreach (var user in userList)
            {
                LogUtility.Log($"user: {user}");
            }
        }
    }
}