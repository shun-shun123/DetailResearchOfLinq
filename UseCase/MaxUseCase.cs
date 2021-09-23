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
            Max04();
        }

        private void Max01()
        {
            var numbers = new[] {0, 1, 2, 3, 4, 5};
            // 単純にシーケンスの中で一番大きい値を取得する
            var max = numbers.Max();
            LogUtility.Log($"max: {max}");

            // selectorを指定することで、比較する際に処理を挟める
            // selectorで処理を行われた後の値が返ってくる
            var divideMax = numbers.Max(i =>
            {
                LogUtility.LogDetail($"numbers.Max.Selector: {i} / 2");
                return i / 2;
            });
            LogUtility.Log($"divideMax: {divideMax}");
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

        private void Max04()
        {
            // Idに対して*-1した結果でMaxを探すので、結果的にはIdの絶対値が一番小さい値を探してくることになる（Idはulongなので）
            var id = ComparableUsers.Max(user => (int)user.Id * -1);
            LogUtility.Log($"ComparableUser.Id * -1 Max: {id}");
        }
    }
}