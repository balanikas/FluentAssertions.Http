using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SampleApplication.RestModels;

namespace SampleApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    [HttpGet]
    [Route("1")]
    public CustomerModel Get1()
    {
        Response.Headers.Add("X-Custom-Header", "1");
        Response.Headers.Add("accept-ranges", new StringValues(new []{"range1","range2"}));

        return new() { Id = 1, Name = "name", Addresses = new List<string> { "address1", "address2" } };
    }
    
    [HttpGet]
    [Route("2")]
    public string GetPlainText()
    {
        return "hello world";
    }
}