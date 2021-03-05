using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.API.ViewModels.Account;
using PomoControl.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [ApiController]
    public class AccountController : PomoController
    {
        [HttpPost("api/Account/SignUp")]
        [Authorize]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel viewModel)
        {
            try
            {
                return StatusCode(501, viewModel);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("api/Account/SignIn")]
        [Authorize]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel viewModel)
        {
            try
            {
                return StatusCode(501, viewModel);
            }
            catch (DomainException ex)
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
