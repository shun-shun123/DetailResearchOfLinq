using System;
using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class ToHashSetUseCase : BaseUseCase
    {
        private sealed class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                // インスタンスがあって、タイプが一緒であれば一致するとみなす強烈な実装
                return true;
            }

            public int GetHashCode(User obj)
            {
                // なのとGetHashCodeは常に0を返す悪魔的実装
                return 0;
            }
        }
        
        public ToHashSetUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ToHashSet01();
            ToHashSet02();
        }

        private void ToHashSet01()
        {
            // HashSet<T>に変換することができる
            // HashSet<T>はDictionary<T, TValue> のKeysのようなもの
            // Set<T>と同様に重複を許さないセットのことで、同値判定にGetHashCodeを使ってる(？)
            var userHashSet = Users.ToHashSet();
            foreach (var user in userHashSet)
            {
                LogUtility.Log($"ToHashSet: {user}");
            }
        }

        private void ToHashSet02()
        {
            // IEqualityComparerを実装したクラスを渡せば、等値判定位部分をカスタマイズできる
            var userHashSetWithComparer = Users.ToHashSet(new UserComparer());
            foreach (var user in userHashSetWithComparer)
            {
                LogUtility.Log($"ToHashSet.WithEqualityComparer: {user}");
            }
        }
    }
}