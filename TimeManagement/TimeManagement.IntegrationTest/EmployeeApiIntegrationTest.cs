using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimeManagement.IntegrationTest
{
    public class EmployeeApiIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {

            using (var client = new TestClientProvide().Client)
            {
                var response = await client.GetAsync("/api/employee");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
