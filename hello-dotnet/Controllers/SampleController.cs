using System;
using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace hello_dotnet.Controllers
{
    [ApiController]
    public class SampleController : ControllerBase
    {
        [Topic("hello")]
        [HttpGet("hello")]
        public string Get()
        {
            Console.WriteLine("Get invoked: Hello DevSum!");
            return "DevSum";
        }
    }
}