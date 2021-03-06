﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AccountController(IAccountService accountService, IUserService userService, ITokenService tokenService)
        {
            _accountService = accountService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel viewModel)
        {
            var response = await _accountService.SignIn(viewModel);

            if (response.Success)
                HttpContext.Response.Headers.Add("accesToken", response.AccessToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel viewModel)
        {
            var response = await _accountService.SignUp(viewModel);

            if (response.Success)
                HttpContext.Response.Headers.Add("accesToken", response.AccessToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("change-status/{status}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(bool status)
        {
            var response = await _userService.ChangeStatus(new ChangeStatusViewModel()
            {
                Active = status, 
                Email = _tokenService.GetEmail(HttpContext).Data
            });
            if (response.Success)
                return StatusCode(200, response.Message);
            return StatusCode(500, new { ErrorMessage= response.Message });
        }
    }
}
