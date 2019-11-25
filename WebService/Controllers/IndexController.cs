using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Index.");        
        }
    }
}