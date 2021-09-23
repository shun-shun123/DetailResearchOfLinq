using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ZipUseCase : BaseUseCase
    {
        public ZipUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Zip01();
            Zip02();
        }

        private void Zip01()
        {
            var indexes = Enumerable.Range(0, Users.Length);
            // Zipによって二つのシーケンスを組み合わせることができる
            // resultSelectorによって合体するシーケンスの値をカスタマイズできる
            var usersWithIndex = Users.Zip(indexes, (user, index) => $"{user}_[{index}]");
            foreach (var info in usersWithIndex)
            {
                LogUtility.Log($"info: {info}");
            }
        }

        private void Zip02()
        {
            var indexes = Enumerable.Range(0, Users.Length);
            // IEnumerable<ValueTuple<User, int>>として返ってくる
            var usersWithIndex = Users.Zip(indexes);
            foreach (var i in usersWithIndex)
            {
                LogUtility.Log($"Zip: First: {i.First}, Second: {i.Second}");
            }
        }
    }
}