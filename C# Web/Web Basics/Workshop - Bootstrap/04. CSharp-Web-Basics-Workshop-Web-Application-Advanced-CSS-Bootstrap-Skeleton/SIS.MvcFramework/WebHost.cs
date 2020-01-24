﻿using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Logging;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Routing;
using SIS.MvcFramework.Sessions;
using System.Linq;
using System.Reflection;

namespace SIS.MvcFramework
{
    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            IHttpSessionStorage httpSessionStorage = new HttpSessionStorage();

            IServiceProvider serviceProvider = new ServiceProvider();

            serviceProvider.Add<ILogger, ConsoleLogger>();

            application.ConfigureServices(serviceProvider);

            AutoRegisterRoutes(application, serverRoutingTable, serviceProvider);

            application.Configure(serverRoutingTable);

            var server = new Server(8000, serverRoutingTable, httpSessionStorage);
            server.Run();
        }

        private static void AutoRegisterRoutes(IMvcApplication application, IServerRoutingTable serverRoutingTable, IServiceProvider serviceProvider)
        {
            var controllers = application.GetType().Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract
                && typeof(Controller).IsAssignableFrom(type));

            foreach (var controllerType in controllers)
            {
                var actions = controllerType
                    .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .Where(method => !method.IsSpecialName && method.DeclaringType == controllerType)
                    .Where(x => x.GetCustomAttributes().All(a => a.GetType() != typeof(NonActionAttribute)));

                foreach (var action in actions)
                {
                    var path = $"/{controllerType.Name.Replace("Controller", string.Empty)}/{action.Name}";

                    var attribute = action.GetCustomAttributes().Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .LastOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpRequestMethod.Get;

                    if (attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if (attribute?.Url != null)
                    {
                        path = attribute.Url;
                    }

                    if (attribute?.ActionName != null)
                    {
                        path = $"/{controllerType.Name.Replace("Controller", string.Empty)}/{attribute.ActionName}";
                    }

                    serverRoutingTable.Add(httpMethod, path, request =>
                    {
                        //request => new UsersController().Login(request)
                        var controllerInstance = serviceProvider.CreateInstance(controllerType) as Controller;
                    controllerInstance.Request = request;

                        //Security Authorization - TODO: Refactor this
                        var controllerPrincipal = controllerInstance.User;
                        var authorizedAttribute = action.GetCustomAttributes()
                        .LastOrDefault(x => x.GetType() == typeof(AuthorizeAttribute)) as AuthorizeAttribute;

                        if (authorizedAttribute != null && !authorizedAttribute.IsInAuthority(controllerPrincipal))
                        {
                            //TODO: Redirect to configured Url
                            return new HttpResponse(HttpResponseStatusCode.Forbidden);
                        }

                        var response = action.Invoke(controllerInstance, new object [0]) as ActionResult;

                        return response;
                    });

                    System.Console.WriteLine(httpMethod + " " + path);
                }
            }
        }
    }
}
