using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq
{
    public class AppendUseCase : BaseUseCase
    {
        public AppendUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Append01();
        }

        private void Append01()
        {
            // シーケンスの末尾に要素が付け加えられる
            var users = Users.Append(new User(100, "append user", 40));
            foreach (var user in users)
            {
                LogUtility.Log($"user: {user.Id}");
            }
        }
    }
}