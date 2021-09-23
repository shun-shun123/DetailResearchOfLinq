using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class PrependUseCase : BaseUseCase
    {
        public PrependUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Prepend01();
        }

        private void Prepend01()
        {
            var numbers = new List<int>{1, 2, 3};
            numbers.Prepend(0);

            // あくまで遅延実行であり、メソッドを実行した時点ではクエリを構成しているだけなので、大元のnumbersに変更はない
            foreach (var i in numbers)
            {
                LogUtility.Log($"i: {i}");
            }

            // これはクエリを構築した上で、foreachで評価をしていくので0が最初に追加されている
            foreach (var i in numbers.Prepend(0))
            {
                LogUtility.Log($"numbers.Prepend: {i}");
            }

            // ToListとか使って即時実行してしまえば、新しいListとして先頭に追加されたものが生成される
            var newNumbers = numbers.Prepend(0).ToList();
            foreach (var i in newNumbers)
            {
                LogUtility.Log($"newNumbers: {i}");
            }
        }
    }
}