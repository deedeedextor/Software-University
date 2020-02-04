using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.Services;
using System;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public HomeController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                var problems = this.problemService
                    .GetAll();

                var result = problems
                    .Select(p => new IndexViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Count = this.submissionService.GetSubmissionsCountById(p.Id)
                    })
                    .ToList();

                return this.View(result, view: "IndexLoggedIn");
            }

            return this.View();

        }
    }
}