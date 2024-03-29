﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> GET()
        {
            string str = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            return new string[] { "PomoControl - API", "Created in 02/21", "by: Henrique Holtz", str };
        }

    }
}
