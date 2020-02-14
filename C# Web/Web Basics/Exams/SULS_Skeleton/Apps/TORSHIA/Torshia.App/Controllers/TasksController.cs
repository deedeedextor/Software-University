using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Globalization;
using System.Linq;
using Torshia.App.ViewModels.Tasks;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(TaskInputViewModel model)
        {
            var taskId = this.tasksService
                .Create(model.Title, model.DueDate, model.Description, model.Participants, model.AffectedSectors);

            if (taskId == null)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var taskFromDb = this.tasksService
                .GetTaskById(id);

            if (taskFromDb == null)
            {
                return this.Redirect("/");
            }

            var taskDetails = new TaskDetailsViewModel
            {
                Title = taskFromDb.Title,
                Level = taskFromDb.AffectedSectors.Count,
                DueDate = taskFromDb.DueDate.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture),
                Participants = taskFromDb.Participants,
                AffectedSectors = string.Join(", ", taskFromDb.AffectedSectors.Select(s => s.Sector.ToString())),
                Description = taskFromDb.Description
            };

            return this.View(taskDetails);
        }
    }
}
