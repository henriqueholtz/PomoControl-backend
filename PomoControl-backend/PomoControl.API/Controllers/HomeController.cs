﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : PomoController
    {
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> GET()
        {
            return new string[] { "PomoControl - API", "Created in 02/21" };
        }
    }
}