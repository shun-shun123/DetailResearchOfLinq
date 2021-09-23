using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class GroupJoinUseCase : BaseUseCase
    {
        public GroupJoinUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            GroupJoin01();
        }

        private void GroupJoin01()
        {
            // outer: _peoples, 最初のシーケンス
            // inner: _pets, 二つ目のシーケンス
            // outerKeySelector: Joinするためのキーを一つ目のシーケンスから取り出す方法
            // innerKeySelector: Joinするためのキーを二つ目のシーケンスから取り出す方法
            // resultSelector: 一つ目のシーケンスの要素と、それにマッチする二つ目のシーケンスに含まれるコレクションからどう結果を生成するかの方法
            // IEqualityComparer: オーバーロードとして用意されており、KeyのEqual判定について使われる
            var group = Persons.GroupJoin(Pets,
                person => person,
                pet => pet.Owner,
                (person, petCollection) => new
                {
                    OwnerName = person.Name,
                    Pets = petCollection.Select(pet => pet.Name)
                });
            foreach (var i in group)
            {
                LogUtility.Log($"Owner: {i.OwnerName}");
                foreach (var pet in i.Pets)
                {
                    LogUtility.Log($"\tPet: {pet}");
                }
            }
        }
    }
}