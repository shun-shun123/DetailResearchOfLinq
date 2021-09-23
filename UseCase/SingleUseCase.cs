using System;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SingleUseCase : BaseUseCase
    {
        public SingleUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Single01();
            Single02();
        }

        private void Single01()
        {
            // Singleは該当する要素が確実に一つだけという保証のもの実行される
            // 該当する要素が一つでない場合には例外を投げる
            var single = Users.Single(user => user.Id == 2);
            LogUtility.Log($"Single: {single}");
        }

        private void Single02()
        {
            try
            {
                var single = Users.Single();
            }
            catch (Exception ex)
            {
                LogUtility.Log($"NotSingle: {ex.Message}");
            }
        }        
    }
}