using HttpServerDemo.Models.Contracts;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServerDemo.Models
{
    public class HttpServer : IHttpServer
    {
        const string NewLine = "\r\n";

        private bool isWorking;
        private readonly TcpListener tcpListener;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, 80);
        }

        public void Start()
        {
            this.tcpListener.Start();
            this.isWorking = true;
            Console.WriteLine("Started!");

            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();

                using var stream = client.GetStream();
                byte[] requestBytes = new byte[100000];

                int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                Console.WriteLine(new string('=', 50));
                Console.WriteLine(stringRequest);

                string responseBody = "<form method='post'><input type='text' name='tweet' placeholder='Enter tweet...' /><input name='name' /><input type='submit' /></form>";
                string response = "HTTP/1.0 200 OK" + NewLine +
                                  "Content-Type: text/html" + NewLine +
                                   "Location: https://google.com" + NewLine +
                                   "Content-Disposition: attachment; filename=index.html" + NewLine +
                                  "Server: MyCustomServer/1.0" + NewLine +
                                  $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                                  responseBody;
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
