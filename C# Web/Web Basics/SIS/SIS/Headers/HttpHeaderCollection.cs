using SIS.HTTP.Common;
using SIS.HTTP.Headers.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            //TO DO Validation for existing parameter(may be throw exeption)
            return this.headers[key];
        }

        public override string ToString()
            => string.Join(GlobalConstants.HttpNewLine, this.headers.Values.Select(h => h.ToString()));
    }
}
