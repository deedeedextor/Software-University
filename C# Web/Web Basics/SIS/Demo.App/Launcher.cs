using Demo.Data;
using SIS.Demo.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;

namespace Demo.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            using (var context = new DemoDbContext())
            {
                context.Database.EnsureCreated();
            }

            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            //[GET] Mappings
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController(request).Index(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/login", request => new UserController().Login(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/register", request => new UserController().Register(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/logout", request => new UserController().Logout(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/home", request => new HomeController(request).Home(request));


            //[POST] Mappings
            serverRoutingTable.Add(HttpRequestMethod.Post, "/login", request => new UserController().LoginConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, "/register", request => new UserController().RegisterConfirm(request));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();

            /*string request =
                "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic 234354545\r\n"
                + "Date: " + DateTime.Now + "\r\n"
                + "Host: localhost:3000\r\n"
                + "\r\n"
                + "username=johndow&password=123";

            HttpRequest httpRequest = new HttpRequest(request);*/

            /*HttpResponseStatusCode statusCode = HttpResponseStatusCode.Unauthorized;*/

            /*HttpResponse response = new HttpResponse(HttpResponseStatusCode.InternalServerError);
            response.AddHeader(new HttpHeader("Host", "localhost:5000"));
            response.AddHeader(new HttpHeader("Date", DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            response.Content = Encoding.UTF8.GetBytes("<h1>Hello World!</h1>");

            Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));*/
        }
    }
}
