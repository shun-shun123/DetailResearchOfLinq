using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class JoinUseCase : BaseUseCase
    {
        public JoinUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Join01();
        }

        private void Join01()
        {
            // IEqualityComparerも渡せる
            var join = Persons.Join(Pets,
                person =>
                {
                    LogUtility.LogDetail($"Join.Person.KeySelector: {person.Name}");
                    return person.Name;
                },
                pet =>
                {
                    LogUtility.LogDetail($"Join.Pet.KeySelector: {pet.Owner.Name}");
                    return pet.Owner.Name;
                },
                (person, pet) => new {Owner = person.Name, Pet = pet.Name});
            foreach (var i in join)
            {
                LogUtility.Log($"Owner: {i.Owner}, Pet: {i.Pet}");
            }
        }
    }
}