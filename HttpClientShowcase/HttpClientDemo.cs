using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientShowcase
{
    public class HttpClientDemo
    {
        private readonly HttpClient _httpClient;
        public HttpClientDemo(HttpClient client) 
        {
            _httpClient = client;
        }
    }
}
