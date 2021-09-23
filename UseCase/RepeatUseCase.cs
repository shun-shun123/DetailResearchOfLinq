using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class RepeatUseCase : BaseUseCase
    {
        public RepeatUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Repeat01();
            Repeat02();
        }

        private void Repeat01()
        {
            // TODO: ここの文字列生成（というか、GC.Alloc）は回数分発生するのかチェック
            var message = Enumerable.Repeat("I like CSharp!", 10);
            foreach (var msg in message)
            {
                LogUtility.Log($"msg: {msg}");
            }
        }

        private void Repeat02()
        {
            var emptyMessage = Enumerable.Repeat("Empty message", 0);
            foreach (var msg in emptyMessage)
            {
                LogUtility.Log($"emptyMsg: {msg}");
            }
        }
    }
}