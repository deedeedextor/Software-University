﻿using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework.Extensions;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace SIS.MvcFramework
{
    public class Controller
    {
        protected Controller()
        {
            ViewData = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> ViewData;

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected void SignIn(IHttpRequest httpRequest, string id, string username, string email)
        {
            httpRequest.Session.AddParameter("Id", id);
            httpRequest.Session.AddParameter("username", username);
            httpRequest.Session.AddParameter("email", email);
        }

        protected void SignOut(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();
        }

        protected bool IsLoggedIn(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        protected ActionResult View([CallerMemberName] string view = null)
        {
            string controllerName = GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = System.IO.File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = ParseTemplate(viewContent);

            HtmlResult htmlResult = new HtmlResult(viewContent);

            return htmlResult;
        }

        protected ActionResult Redirect(string url)
        {
            return new RedirectResult(url);
        }

        protected ActionResult Xml(object obj)
        {
            return new XmlResult(obj.ToXml());
        }

        protected ActionResult Json(object obj)
        {
            return new JsonResult(obj.ToJson());
        }

        protected ActionResult File()
        {
            return null;
        }
    }
}