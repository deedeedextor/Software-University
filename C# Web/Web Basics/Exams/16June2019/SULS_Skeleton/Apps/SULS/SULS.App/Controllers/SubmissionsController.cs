using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService submissionService;
        private readonly IProblemService problemService;

        public SubmissionsController(ISubmissionService submissionService, IProblemService problemService)
        {
            this.submissionService = submissionService;
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService
                .GetById(id);

            var result = new CreateSubmissionViewModel { Name = problem.Name, ProblemId = problem.Id };

            return this.View(result);
        }
    }
}
