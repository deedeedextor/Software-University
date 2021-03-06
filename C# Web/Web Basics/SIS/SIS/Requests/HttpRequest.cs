﻿using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Sessions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Cookies = new HttpCookieCollection();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set ; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length != 3 || requestLine[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNullOrEmpty(queryString, nameof(queryString));

            return !(string.IsNullOrEmpty(queryString) || queryParameters.Length < 1);
        }

        private bool HasQueryString()
        {
            return this.Url.Split('?').Length > 1;
        }

        private IEnumerable<string> ParsePlainRequestsHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod method;
            bool isParsed = HttpRequestMethod.TryParse(requestLine[0], true, out method);

            if (!isParsed)
            {
                throw new BadRequestException(string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage, requestLine[0]));
            }

            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseHeaders(string[] plainHeaders)
        {
            plainHeaders.Select(plainHeader => plainHeader.Split(new[] { ": " }
                   , StringSplitOptions.RemoveEmptyEntries))
                   .ToList()
                   .ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.Cookie))
            {
                string value = this.Headers.GetHeader(HttpHeader.Cookie).Value;
                string[] unparsedCookies = value.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var unparsedCookie in unparsedCookies)
                {
                    string[] cookieKeyValuePair = unparsedCookie.Split(new[] { '=' }, 2);

                    HttpCookie cookie = new HttpCookie(cookieKeyValuePair[0], cookieKeyValuePair[1], false);

                    this.Cookies.AddCookie(cookie);
                }
            }
        }

        private void ParseRequestQueryParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split('?', '#')[1]
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList()
                    .ForEach(queryParameterKeyValuePair => this.QueryData.Add(queryParameterKeyValuePair[0], queryParameterKeyValuePair[1]));
            }
        }

        private void ParseRequestFormDataParameters(string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {
                //TO DO Prase Multiple Parameters By Name
                formData
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList()
                    .ForEach(queryParameterKeyValuePair => this.FormData.Add(queryParameterKeyValuePair[0], queryParameterKeyValuePair[1]));
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(this.ParsePlainRequestsHeaders(splitRequestContent).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
