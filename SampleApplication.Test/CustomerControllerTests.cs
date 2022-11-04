using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleApplication;
using SampleApplication.RestModels;
using Xunit;
using Xunit.Abstractions;

namespace SampleApplication.Test;

public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;
    private readonly ITestOutputHelper _output;

    public BasicTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = output;
    }

    [Fact]
    public async Task Get_ShouldSucceed()
    {
        var response = await _factory.CreateClient().GetAsync("/api/customers/1");
        CustomerModel expected = new() { Name = "name", Addresses = new List<string> { "address1", "address2" } };


        response.Should()
        .HaveContent(expected, options => options.Excluding(x => x.Id));
        
        response.Should()
            .HaveContentMatching<CustomerModel>(x => x.Addresses.Contains("address2") && x.Name == "name");
        
        response.Should()
            .HaveContentHeaderValue(HttpResponseHeader.ContentType, "application/json; charset=utf-8")
            .And
            .HaveResponseHeaderValues(HttpResponseHeader.AcceptRanges, new[] { "range1", "range2" })
            .And
            .HaveResponseHeaderValue("X-Custom-Header", "1")
            .And
            .HaveResponseHeader("X-Custom-Header");
    }

    [Fact]
    public async Task GetPlainText_ShouldSucceed()
    {
        var response = await _factory.CreateClient().GetAsync("/api/customers/2");
        var expected = "hello world";
        //
        // response.Should()
        //     .HaveSuccessStatusCode()
        //     .And
        //     .HaveContent(expected);
        //
        // response.Should()
        //     .HaveContentMatching(x => x.StartsWith("hello"));
        //
        // response.Should()
        //     .HaveSuccessStatusCode()
        //     .And
        //     .HaveContentHeaderValue(HttpResponseHeader.ContentType, "text/plain; charset=utf-8");
    }
}