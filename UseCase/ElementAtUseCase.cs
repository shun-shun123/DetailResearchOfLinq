using System;
using System.Linq;

namespace DetailResearchOfLinq
{
    public class ElementAtUseCase : BaseUseCase
    {
        public ElementAtUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ElementAt01();
            ElementAt02();
        }

        private void ElementAt01()
        {
            // シーケンスの任意番目の値を取り出す
            var first = Users.ElementAt(0);
            LogUtility.Log($"first: {first.Name}");
            
            var last = Users.ElementAt(Users.Length - 1);
            LogUtility.Log($"last: {last.Name}");
        }

        private void ElementAt02()
        {
            var empty = new int[0];
            try
            {
                // 要素がないと例外を投げる
                var first = empty.ElementAt(0);
                LogUtility.Log($"Empty.First: {first}");
            }
            catch (Exception ex)
            {
                LogUtility.Log(ex.Message);
            }
        }
    }
}