using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Result;
using System.Collections.Generic;

namespace IRunes.App.Controllers
{
    public class InfoController : Controller
    {
        public IHttpResponse About(IHttpRequest request)
        {
            return this.View();
        }

        [NonAction]
        public override string ToString()
        {
            return base.ToString();
        }

        public ActionResult Json(IHttpRequest request)
        {
            return Json(new List<object>() {
            new
            {
                Name = "Pesho",
                Age = 25,
                Occupation = "Manager",
            },

            new
            {
                Name = "Pesho",
                Age = 25,
                Occupation = "Manager",
            },

            new
            {
                Name = "Pesho",
                Age = 25,
                Occupation = "Manager",
            },
            });
        }
    }
}
