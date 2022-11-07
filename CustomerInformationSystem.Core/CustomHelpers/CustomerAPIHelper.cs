using System;
using System.Net.Http;

namespace CustomerInformationSystem.Core.CustomHelpers
{
    public class CustomerAPIHelper
    {
        public HttpClient InitializeAPI()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:48494/");
            return client;
        }
    }
}
