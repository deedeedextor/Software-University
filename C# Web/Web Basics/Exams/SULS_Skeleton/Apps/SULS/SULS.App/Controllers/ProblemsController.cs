using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public ProblemsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProblemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var problem = this.problemService.CreateProblem(model.Name, model.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemService
                .GetById(id);

            var result = new DetailsProblemViewModel()
            {
                Name = problem.Name,
                Submissions = this.submissionService.GetSubmissionsForProblemById(problem.Id)
                .Select(s => new DetailsSubmissionViewModel
                {
                    Id = s.Id,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy"),
                    MaxPoints = s.Problem.Points,
                    FinalPoints = 100,
                    Username = s.User.Username
                })
                .ToList()
            };

            return this.View(result);
        }
    }
}
