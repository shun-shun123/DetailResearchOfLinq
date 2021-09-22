using System.Linq;

namespace DetailResearchOfLinq
{
    public class ElementAtOrDefaultUseCase : BaseUseCase
    {
        public ElementAtOrDefaultUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ElementAtOrDefault01();
        }

        private void ElementAtOrDefault01()
        {
            // 例外は吐かず、デフォルト値を返す（null）
            var outOfRange = Users.ElementAtOrDefault(10000);
            LogUtility.Log($"OutOfRange.User: {outOfRange?.Name}");
        }
    }
}