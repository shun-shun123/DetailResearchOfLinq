using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ToArrayUseCase : BaseUseCase
    {
        public ToArrayUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ToArray01();
        }

        private void ToArray01()
        {
            // 即時実行して配列を生成する
            // LINQは基本的に遅延実行だが、一部のメソッドを呼び出すことで即時実行される。
            // ToArrayもこれに該当し、呼び出した時点で即時実行される
            // ToArrayが呼び出されるたびに即時実行される
            var ids = Users.Select(user =>
            {
                LogUtility.LogDetail($"Select.ToArray: {user}");
                return user.Id;
            })
                .ToArray()
                .Where(id =>
                {
                    LogUtility.Log($"ToArray.Where: {id}");
                    return id % 2 == 0;
                })
                .ToArray();

            foreach (var id in ids)
            {
                LogUtility.Log($"id: {id}");
            }
        }
    }
}