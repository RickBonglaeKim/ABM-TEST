using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(InputDocument inputDocument)
        {
            try
            {
                if (inputDocument.DeclarationList.Declaration.Command != "DEFAULT") return StatusCode(-1);
                if (inputDocument.DeclarationList.Declaration.DeclarationHeader.SiteID != "DUB") return StatusCode(-2);

                return StatusCode(0);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}