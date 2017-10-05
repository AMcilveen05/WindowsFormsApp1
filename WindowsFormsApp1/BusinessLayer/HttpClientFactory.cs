using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BusinessLayer
{
    public class HttpClientFactory : IHttpClientFactory
    {
        static string baseAddress = "http://localhost:49411/api/";

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49411/api/");
            return client;
        }
    }
}
