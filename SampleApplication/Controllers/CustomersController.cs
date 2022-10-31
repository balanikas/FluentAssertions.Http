using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.RestModels;

namespace SampleApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public CustomerModel Get()
    {
        return new() { Id = 1, Name = "name", Addresses = new List<string> { "address1", "address2" } };
    }
}