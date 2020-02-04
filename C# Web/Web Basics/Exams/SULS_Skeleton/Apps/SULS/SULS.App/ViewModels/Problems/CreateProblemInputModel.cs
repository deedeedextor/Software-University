using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Problems
{
    public class CreateProblemInputModel
    {
        private const string ProblemErrorMessage = "Username length must be between 5 and 20!";
        private const string PointsErrorMessage = "Points must be between 50 and 300!";

        [RequiredSis]
        [StringLengthSis(5, 20, ProblemErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsErrorMessage)]
        public int Points { get; set; }
    }
}
