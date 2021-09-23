using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class ToLookupUseCase : BaseUseCase
    {
        public ToLookupUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ToLookup01();
        }

        private void ToLookup01()
        {
            // keySelector: LookupテーブルのKeyの取得方法
            // elementSelector: LookupテーブルのKeyに対応するIEnumerable<T>の要素の取得方法
            // Keyに対するIEqualityComparer<TKey>も渡せるけど、他と同じなので割愛
            var petLookup = Pets.ToLookup(pet => pet.Owner.Name,
                pet => pet.Name);

            foreach (IGrouping<string, string> pet in petLookup)
            {
                LogUtility.Log($"PetOwner: {pet.Key}");
                foreach (var p in pet)
                {
                    LogUtility.Log($"\tPet: {p}");
                }
            }
        }
    }
}