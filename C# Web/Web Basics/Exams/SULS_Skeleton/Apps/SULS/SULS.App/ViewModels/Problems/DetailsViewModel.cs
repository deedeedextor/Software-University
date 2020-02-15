using SULS.App.ViewModels.Submissions;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            this.Problems = new List<ProblemDetailsSubmissionViewModel>();
        }

        public string Name { get; set; }

        public IEnumerable<ProblemDetailsSubmissionViewModel> Problems { get; set; }
    }
}
