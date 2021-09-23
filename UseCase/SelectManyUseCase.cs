using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class SelectManyUseCase : BaseUseCase
    {
        public SelectManyUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Setup();
            SelectMany01();
            SelectMany02();
            SelectMany03();
        }

        private void Setup()
        {
            foreach (var pet in Pets)
            {
                foreach (var person in Persons)
                {
                    if (pet.Owner.Name == person.Name)
                    {
                        person.Pets.Add(pet);
                    }
                }
            }
        }

        private void SelectMany01()
        {
            // collectionSelector: input sequenceからcollectionを取り出す関数
            // resultSelector: intermediate sequenceから結果を生成する関数
            // Selectと異なり、Collectionを取り出して、それに対してさらにSelectをかけるようなイメージ
            var query = Persons.SelectMany(person =>
                {
                    LogUtility.LogDetail($"SelectMany.collectionSelector: {person}");
                    return person.Pets;
                },
                (person, pet) =>
                {
                    LogUtility.LogDetail($"person: {person}, pet: {pet}");
                    return new {Person = person, pet = pet};
                });
            foreach (var i in query)
            {
                LogUtility.Log($"SelectMany: person: {i.Person}, pet: {i.pet}");
            }
        }

        private void SelectMany02()
        {
            // Select vs SelectMany
            
            // SelectではあくまでIEnumerable<List<Pet>>として取り出す
            var select = Persons.Select(person => person.Pets);
            foreach (var i in select)
            {
                LogUtility.Log($"Select.Result: {i}");
            }

            // SelectManyではIEnumerable<Pet>として取り出す
            var selectMany = Persons.SelectMany(person => person.Pets);
            foreach (var i in selectMany)
            {
                LogUtility.Log($"SelectMany.Result: {i}");
            }
        }

        private void SelectMany03()
        {
            // indexだって取れる
            var selectMany = Persons.SelectMany((person, i) =>
            {
                LogUtility.LogDetail($"SelectMany(index): {person}_{i}");
                return person.Pets;
            });
            foreach (var i in selectMany)
            {
            }
        }
    }
}