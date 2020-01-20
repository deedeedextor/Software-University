using HttpServerDemo.Models;
using System;

namespace HttpServerDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.Start();
        }
    }
}
