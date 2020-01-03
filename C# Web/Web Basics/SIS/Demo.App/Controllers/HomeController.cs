using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.Demo.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            this.HttpRequest = request;
            return this.View();
        }
    }
}
