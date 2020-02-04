using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submissions
{
    public class CreateSubmissionInputModel
    {
        private const string CodeErrorMessage = "Code legth must be between 30 and 800";
        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMessage)]
        public string Code { get; set; }

        [RequiredSis]
        public string ProblemId { get; set; }
    }
}
