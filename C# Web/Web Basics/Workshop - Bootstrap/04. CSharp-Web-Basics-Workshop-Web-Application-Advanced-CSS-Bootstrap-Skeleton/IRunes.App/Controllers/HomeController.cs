﻿using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (this.IsLoggedIn(httpRequest))
            {
                this.ViewData["Username"] = httpRequest.Session.GetParameter("username");

                return View("Home");
            }

            return this.View();
        }
    }
}
