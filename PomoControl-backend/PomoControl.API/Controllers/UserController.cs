using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.API.ViewModels.User;
using PomoControl.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : PomoController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel user )
        {
            try
            {

                return Ok(user);
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
