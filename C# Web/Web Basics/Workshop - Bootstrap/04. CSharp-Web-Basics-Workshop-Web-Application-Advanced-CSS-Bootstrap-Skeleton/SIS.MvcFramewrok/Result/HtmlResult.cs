﻿using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.MvcFramework.Result
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode) : base(responseStatusCode)
        {
            Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            Content = Encoding.UTF8.GetBytes(content);
        }
    }
}