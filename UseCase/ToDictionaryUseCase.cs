using System;
using System.Collections.Generic;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class ToDictionaryUseCase : BaseUseCase
    {
        private sealed class AgeComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj;
            }
        }
        
        public ToDictionaryUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ToDictionary01();
            ToDictionary02();
            ToDictionary03();
            ToDictionary04();
        }

        private void ToDictionary01()
        {
            // keySelector: DictionaryのKeyとなる値の取得方法
            // elementSelector: DictionaryのValueとなる値の取得方法
            // ToDictionaryも即時実行
            var usersDict = Users
                .Where(user =>
                {
                    LogUtility.LogDetail($"Where.ToDictionaryが実行されてる{user}");
                    return user.Id % 2 == 0;
                })
                .ToDictionary(user => user.Id,
                user => user.Name);
            LogUtility.Log($"usersDict[0]: {usersDict[0]}");
        }

        private void ToDictionary02()
        {
            try
            {
                Users = Users.Prepend(new User(11, null, 100)).ToArray();

                // keySelectorでnullがきた場合には例外を発生する
                var usersDict = Users.ToDictionary(user => user.Name);
            }
            catch (Exception ex)
            {
                LogUtility.Log($"ToDictionaryのkeySelectorではnullを取得できません{ex.Message}");
            }
        }

        private void ToDictionary03()
        {
            try
            {
                Users = Users.Prepend(new User(1, "", 101)).ToArray();
                // keySelectorでの返り値に重複したものが来たら例外を投げる
                var usersDict = Users.ToDictionary(user => user.Id);
            }
            catch (Exception ex)
            {
                LogUtility.Log($"keySelectorが重複したものを返すと例外を投げます{ex.Message}");
            }
        }

        private void ToDictionary04()
        {
            // IEqualityComparerを渡すこともできる
            // TODO: これは内部的に生成するDictionaryのコンストラクタ引数として渡されてるのかな？
            var usersDict = Users.ToDictionary(user => user.Age, new AgeComparer());
            LogUtility.Log($"User.Age[3]: {usersDict[3]}");
        }
    }
}