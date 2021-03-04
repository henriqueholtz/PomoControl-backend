using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomoControl.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : PomoController
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            try
            {

                return Ok();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
