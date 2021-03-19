using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Account;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel viewModel)
        {
            var response = await _accountService.SignIn(viewModel);

            if (response.Success)
                HttpContext.Response.Headers.Add("accesToken", response.Data);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel viewModel)
        {
            var response = await _accountService.SignUp(viewModel);

            if (response.Success)
                HttpContext.Response.Headers.Add("accesToken", response.Data);

            return StatusCode(response.StatusCode, response);
        }

    }
}
