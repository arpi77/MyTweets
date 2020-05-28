using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTweets.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/test")]
        public IActionResult Get()
        {
            return Ok(new { Name = "Arpi" });
        }
    }
}