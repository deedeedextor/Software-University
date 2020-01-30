using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }
    }
}