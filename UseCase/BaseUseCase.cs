using DetailResearchOfLinq.Data;
using DetailResearchOfLinq.Utility;

namespace DetailResearchOfLinq
{
    public abstract class BaseUseCase
    {
        protected User[] Users;

        protected BaseUseCase(int size)
        {
            Users = UserFactory.CreateUserArray(size);
        }

        public virtual void Execute()
        {
            LogUtility.Log($"====={GetType().Name}=====");
        }
    }
}