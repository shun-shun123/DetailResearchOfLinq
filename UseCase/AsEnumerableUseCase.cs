using System;
using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class AsEnumerableUseCase : BaseUseCase
    {
        public class Clump<T> : List<T>
        {
            public IEnumerable<T> Where(Func<T, bool> predicate)
            {
                LogUtility.LogDetail("In Clump's implementation of Where()");
                return Enumerable.Where(this, predicate);
            }
        }


        public AsEnumerableUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            AsEnumerable01();
        }

        private void AsEnumerable01()
        {
            var fruitClump = new Clump<string>
            {
                "apple", "banana", "orange", "grape"
            };

            // これはClump.Whereが呼び出される
            var query1 = fruitClump.Where(fruit => fruit.Contains("o"));

            // こっちはIEnumerableにキャストされているので、LINQのWhereが呼び出される
            var query2 = fruitClump.AsEnumerable().Where(fruit => fruit.Contains("o"));
        }
    }
}