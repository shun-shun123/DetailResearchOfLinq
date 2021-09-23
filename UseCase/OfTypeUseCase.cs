using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class OfTypeUseCase : BaseUseCase
    {
        public OfTypeUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            OfType01();
        }

        private void OfType01()
        {
            List<object> objects = new List<object>
            {
                "Hello",
                "World!",
                2021,
                09,
                23
            };

            // stringにキャストできるものだけのシーケンスになる
            // Cast<T>とは異なり、キャストできないものがあってもそれはシーケンスに含まれなくなるだけで、例外は投げない
            // OfTypeは数少ない非ジェネリクス型のコレクションに対しても使えるメソッド（IEnumerable）に対しても実装されているから
            var strs = objects.OfType<string>();
            foreach (var str in strs)
            {
                LogUtility.Log($"string: {str}");
            }
            
            // intにキャストできるものだけのシーケンスになる
            var dates = objects.OfType<int>();
            foreach (var i in dates)
            {
                LogUtility.Log($"int: {i}");
            }
        }
    }
}