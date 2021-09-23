using System;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class MaxUseCase : BaseUseCase
    {
        public MaxUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Max01();
            Max02();
            Max03();
        }

        private void Max01()
        {
            var numbers = new[] {0, 1, 2, 3, 4, 5};
            // 単純にシーケンスの中で一番大きい値を取得する
            var max = numbers.Max();
            LogUtility.Log($"max: {max}");
        }

        private void Max02()
        {
            try
            {
                // TResultに該当する型がIComparable<T>がIComparableを実装していないと例外を吐く
                var maxUser = Users.Max();
                LogUtility.Log($"maxUser: {maxUser}");
            }
            catch (Exception ex)
            {
                LogUtility.Log($"{typeof(User)}がIComparable<User>を実装していないので例外({ex.Message})");
            }
        }

        private void Max03()
        {
            try
            {
                // IComparable<T>を実装しているクラスに対しては、Maxを適用できる
                var maxComparableUser = ComparableUsers.Max();
                foreach (var user in ComparableUsers)
                {
                    LogUtility.Log($"user: {user}");
                }
                LogUtility.Log($"maxComparableUser: {maxComparableUser}");
            }
            catch (Exception ex)
            {
                LogUtility.Log("ここは呼ばれない" + ex.Message);
            }
        }
    }
}