using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServerDemo.Models.Contracts
{
    public interface IHttpServer
    {
        void Start();

        void Stop();
    }
}
