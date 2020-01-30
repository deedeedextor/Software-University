using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return this.View();
            }

            return this.View("IndexLoggedIn");
        }
    }
}