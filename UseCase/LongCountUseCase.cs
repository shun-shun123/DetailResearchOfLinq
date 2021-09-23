using System;
using System.Linq;
using DetailResearchOfLinq.Data;

namespace DetailResearchOfLinq.UseCase
{
    public class LongCountUseCase : BaseUseCase
    {
        public LongCountUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            LongCount01();
        }

        private void LongCount01()
        {
            // Count()の返り値がlongなやつ
            var users1 = new User[1];
            var users2 = new User[1];
            var combine = users1.Concat(users2);
            var countInt = combine.Count();
            var countLong = combine.LongCount();
            LogUtility.Log($"countInt: {countInt}({countInt.GetType()})");
            LogUtility.Log($"countLong: {countLong}({countLong.GetType()})");
        }
    }
}