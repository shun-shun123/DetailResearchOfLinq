using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq
{
    public class GroupJoinUseCase : BaseUseCase
    {
        private sealed class People
        {
            public string Name;
        }

        private sealed class Pet
        {
            public string Name;
            public People Owner;
        }

        private List<People> _peoples;

        private List<Pet> _pets;
        
        public GroupJoinUseCase(int size) : base(size)
        {
            _peoples = new List<People>(new[]
            {
                new People {Name = "User_1"},
                new People {Name = "User_2"},
                new People {Name = "User_3"},
            });

            _pets = new List<Pet>(new[]
            {
                new Pet {Name = "Pet_1", Owner = _peoples[0]},
                new Pet {Name = "Pet_2", Owner = _peoples[1]},
                new Pet {Name = "Pet_3", Owner = _peoples[2]},
                new Pet {Name = "Pet_4", Owner = _peoples[0]},
                new Pet {Name = "Pet_5", Owner = _peoples[0]},
                new Pet {Name = "Pet_6", Owner = _peoples[1]},
                new Pet {Name = "Pet_7", Owner = _peoples[2]},
                new Pet {Name = "Pet_8", Owner = _peoples[0]},
            });
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
            var group = _peoples.GroupJoin(_pets,
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