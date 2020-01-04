using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.Demo.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest httpRequest)
        {
            this.HttpRequest = httpRequest;
        }

        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View();
        }

        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect("/login");
            }

            this.ViewData["Username"] = this.HttpRequest.Session.GetParameter("username");

            return this.View();
        }
    }
}
