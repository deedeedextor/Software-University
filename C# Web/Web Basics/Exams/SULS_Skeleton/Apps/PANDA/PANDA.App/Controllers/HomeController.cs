using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Mapping;
using PANDA.Services;

namespace MUSACA.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View("IndexLoggedIn");
            }

            return this.View();
        }
    }
}