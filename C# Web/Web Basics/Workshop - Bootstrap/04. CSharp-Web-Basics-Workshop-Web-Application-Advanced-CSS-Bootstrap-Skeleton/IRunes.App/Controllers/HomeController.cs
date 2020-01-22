using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Result;
using System.Collections.Generic;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public ActionResult IndexSlash()
        {
            return this.Index();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Test(IEnumerable<string> list)
        {
            return this.View();
        }
    }
}
