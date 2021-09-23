using System.Linq;

namespace DetailResearchOfLinq.UseCase
{
    public class AverageUseCase : BaseUseCase
    {
        public AverageUseCase(int size) : base(size)
        {
        }

        public override void Execute()
        {
            base.Execute();
            Average01();
        }

        private void Average01()
        {
            // intだろうが、平均値はdoubleで返ってくる
            var average = Users.Select(user => user.Age)
                .Average();
            LogUtility.Log($"average: {average}");

            var newAverage = Users.Select(user => user.Age)
                .Average(age => age * 2);
            LogUtility.Log($"NewAverage: {newAverage}");
        }
    }
}