﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.HTTP.Common;
using SIS.MvcFramework.Routing;
using SIS.MvcFramework.Sessions;

namespace SIS.MvcFramework
{
    public class Server
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener tcpListener;

        private readonly IServerRoutingTable serverRoutingTable;

        private readonly IHttpSessionStorage httpSessionStorage;

        private bool isRunning;

        public Server(int port, IServerRoutingTable serverRoutingTable, IHttpSessionStorage httpSessionStorage)
        {
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));
            CoreValidator.ThrowIfNull(httpSessionStorage, nameof(httpSessionStorage));

            this.port = port;
            this.serverRoutingTable = serverRoutingTable;
            this.httpSessionStorage = httpSessionStorage;

            tcpListener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);
        }

        private async Task ListenAsync(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable, this.httpSessionStorage);
            await connectionHandler.ProcessRequestAsync();
        }

        public void Run()
        {
            tcpListener.Start();
            isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{port}");

            while (isRunning)
            {
                var client = tcpListener.AcceptSocketAsync().GetAwaiter().GetResult();

                Task.Run(() => ListenAsync(client));
            }
        }
    }
}
