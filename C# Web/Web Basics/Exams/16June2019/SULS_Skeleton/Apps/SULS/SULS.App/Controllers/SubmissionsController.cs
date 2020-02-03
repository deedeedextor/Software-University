using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
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

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateSubmissionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Create(model.ProblemId);
            }

            this.submissionService.CreateSubmission(model.Code, model.ProblemId, this.User.Id);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var submission = this.submissionService.DeleteById(id);

            return this.Redirect("/");
        }
    }
}
