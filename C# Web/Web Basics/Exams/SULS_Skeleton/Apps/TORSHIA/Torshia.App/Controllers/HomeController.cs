using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System.Linq;
using Torshia.App.ViewModels.Home;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksService tasksService;

        public HomeController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        private IActionResult Index()
        {
            if (IsLoggedIn())
            {
                var tasks = this.tasksService.GetAllByName()
                    .Select(t => new HomeTaskViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Level = t.AffectedSectors.Count,
                    }).ToList();

                return this.View(new HomeViewModel { Username = this.User.Username, Tasks = tasks}, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
