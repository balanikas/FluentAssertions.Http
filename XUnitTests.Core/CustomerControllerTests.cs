using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleApplication.RestModels;
using Xunit;

namespace XUnitTests.Core
{
    public class BasicTests : IClassFixture<WebApplicationFactory<SampleApplication.Startup>>
    {
        private readonly WebApplicationFactory<SampleApplication.Startup> _factory;

        public BasicTests(WebApplicationFactory<SampleApplication.Startup> factory) => _factory = factory;

        [Fact]
        public async Task Get_ShouldSucceed()
        {
            var response = await _factory.CreateClient().GetAsync("/api/customers");

            var expected = new CustomerModel { Name = "name", Addresses = new List<string> { "address1", "address2"}};

            response.Should()
                .HaveStatusCode(HttpStatusCode.OK)
                .And
                .HaveHeaderForTransferEncoding(new TransferCodingHeaderValue("value"))
                .And
                .HaveHeader("customerHeader", "headerValue")
                .And
                .HaveContent<CustomerModel>(expected, options => options.Excluding(x => x.Id));
        }
    }
}
