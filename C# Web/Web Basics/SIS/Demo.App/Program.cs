using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using System;

namespace Demo.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*string request =
                "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic 234354545\r\n"
                + "Date: " + DateTime.Now + "\r\n"
                + "Host: localhost:3000\r\n"
                + "\r\n"
                + "username=johndow&password=123";

            HttpRequest httpRequest = new HttpRequest(request);*/

            HttpResponseStatusCode statusCode = HttpResponseStatusCode.Unauthorized;

            Console.WriteLine((int) statusCode);
        }
    }
}
