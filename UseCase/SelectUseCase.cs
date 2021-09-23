using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SelectUseCase : BaseUseCase
    {
        public SelectUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Select01();
            Select02();
        }

        private void Select01()
        {
            // TSourceから任意の値を取り出したシーケンスを作成できる
            var id = Users.Select(user => user.Id);
            foreach (var i in id)
            {
                LogUtility.Log($"user.id: {i}");
            }
        }

        private void Select02()
        {
            // インデックスが知りたい場合には、それ用のオーバーロードがある
            var idWithIndex = Users.Select((user, i) => $"{i}_{user.Id}");
            foreach (var i in idWithIndex)
            {
                LogUtility.Log($"(i, id): ({i})");
            }
        }
    }
}