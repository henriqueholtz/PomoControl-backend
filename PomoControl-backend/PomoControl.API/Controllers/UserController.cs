using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.Core.Exceptions;
using PomoControl.Service.ViewModels.User;
using System;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public /*async*/ Task<IActionResult> Create([FromBody] CreateUserViewModel user)
        {
            throw new NotImplementedException();
            //try
            //{
            //    //var response
            //    return StatusCode(501, user);
            //}
            //catch (DomainException ex)
            //{
            //    return BadRequest(ex);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}
        }
    }
}
