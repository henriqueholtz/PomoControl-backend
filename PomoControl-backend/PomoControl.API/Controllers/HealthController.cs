using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Health()
        {
            await Task.Delay(150);
            return Ok();
        }
    }
}
