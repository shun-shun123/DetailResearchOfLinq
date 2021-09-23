using DetailResearchOfLinq.Data;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq.UseCase
{
    public abstract class BaseUseCase
    {
        protected User[] Users;

        protected Person[] Persons;

        protected Pet[] Pets;

        protected ComparableUser[] ComparableUsers;

        protected BaseUseCase(int size)
        {
            Users = UserFactory.CreateUserArray(size);
            Persons = PersonFactory.CreatePersonArray(size);
            Pets = PetFactory.CreatePetArray(size);
            ComparableUsers = ComparableUserFactory.CreateComparableUserInRandomOrder(size);
        }

        public virtual void Execute()
        {
            LogUtility.Log($"====={GetType().Name}=====");
        }
    }
}