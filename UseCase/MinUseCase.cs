using System;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class MinUseCase : BaseUseCase
    {
        public MinUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Min01();
            Min02();
            Min03();
        }

        private void Min01()
        {
            var numbers = new[] {0, 1, 2, 3, 4, 5};
            var min = numbers.Min();
            LogUtility.Log($"min: {min}");

            // Maxと同様にselectorを挟むこともできる
            var negativeMin = numbers.Min(i => i * -1);
            LogUtility.Log($"negativeMin: {negativeMin}");
        }

        private void Min02()
        {
            try
            {
                var minUser = Users.Min();
            }
            catch (Exception ex)
            {
                LogUtility.Log($"IComparable<T>を実装していないので、例外を吐く{ex.Message}");
            }
        }

        private void Min03()
        {
            // IComparable<T>を実装したComparableUserなら使える
            var minComparableUser = ComparableUsers.Min();
            LogUtility.Log($"ComparableUser.Min: {minComparableUser}");
        }
    }
}