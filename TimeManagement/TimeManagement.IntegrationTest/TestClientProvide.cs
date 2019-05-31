using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TimeManagement.Service;

namespace TimeManagement.IntegrationTest
{
    public class TestClientProvide
    {
        public HttpClient Client { get; private set; }

        public TestClientProvide()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
