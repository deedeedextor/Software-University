using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Data;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly SULSContext db;

        public ProblemsController(IProblemService problemService, SULSContext db)
        {
            this.problemService = problemService;
            this.db = db;
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
            var viewModel = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Problems = x.Submissions.Select(s =>
                    new ProblemDetailsSubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        AchievedResult = s.AchievedResult,
                        SubmissionId = s.Id,
                        MaxPoints = x.Points,
                        Username = s.User.Username,
                    })
                }).FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
