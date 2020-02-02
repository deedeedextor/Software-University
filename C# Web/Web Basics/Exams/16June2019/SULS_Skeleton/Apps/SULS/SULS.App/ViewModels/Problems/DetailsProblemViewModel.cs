using SULS.App.ViewModels.Submissions;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class DetailsProblemViewModel
    {
        public DetailsProblemViewModel()
        {
            this.Submissions = new List<DetailsSubmissionViewModel>();
        }
        public string Name { get; set; }

        public List<DetailsSubmissionViewModel> Submissions { get; set; }
    }
}
