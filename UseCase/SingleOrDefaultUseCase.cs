using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SingleOrDefaultUseCase : BaseUseCase
    {
        public SingleOrDefaultUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            SingleOrDefault01();
            SingleOrDefault02();
            SingleOrDefault03();
        }

        private void SingleOrDefault01()
        {
            // 普通のSingleとしての機能を持った上で、Nullable<T>を返す
            var single = Users.SingleOrDefault(user => user.Id == 3);
            LogUtility.Log($"SingleOrDefault: {single}");
        }

        private void SingleOrDefault02()
        {
            // 見つからない場合はデフォルト値を返す
            var notFound = Users.SingleOrDefault(user => user.Id == 1000);
            LogUtility.Log($"SingleOrDefault.NotFound: {notFound}");
        }

        private void SingleOrDefault03()
        {
            // デフォルト地が望む値でない場合のテクニック
            var pageNumbers = new int[0];
            // もし空のシーケンスであれば1を返すDefaultIfEmpty(1)とSingleを組み合わせることで、
            // 該当するものがない際に帰ってくるデフォルト値をカスタマイズできる
            var firstPage = pageNumbers.DefaultIfEmpty(1).Single();
            LogUtility.Log($"FirstPage: {firstPage}");
        }
    }
}