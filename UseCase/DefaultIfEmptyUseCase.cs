using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class DefaultIfEmptyUseCase : BaseUseCase
    {
        public DefaultIfEmptyUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            DefaultIfEmpty01();
            DefaultIfEmpty02();
        }

        private void DefaultIfEmpty01()
        {
            // シーケンスが値を持っていたらそれをそのまま返す
            var defaultValue = Users.DefaultIfEmpty();
            foreach (var val in defaultValue)
            {
                LogUtility.Log($"Users.DefaultIfEmpty: {val}");
            }
        }

        private void DefaultIfEmpty02()
        {
            // シーケンスが値を持っていなかったら、デフォルト値を返す
            var emptyNumbers = new int[0];
            var defaultValue = emptyNumbers.DefaultIfEmpty(0);
            foreach (var val in defaultValue)
            {
                LogUtility.Log($"emptyNumbers.DefaultIfEmpty: {val}");
            }
        }
    }
}