using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Tools
{
    public class ServiceConfiguration
    {
        public static HttpClient InitClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:57960/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
