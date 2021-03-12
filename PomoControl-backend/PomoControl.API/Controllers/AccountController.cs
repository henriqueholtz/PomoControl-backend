using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.API.Utilities;
using PomoControl.Core.Exceptions;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Account;
using System;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : PomoController
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
            try
            {
                var response = await _accountService.SignIn(viewModel);

                //Add Bearer Token in header of response ?

                return StatusCode(response.StatusCode, response);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
            catch(ServiceException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel viewModel)
        {
            try
            {
                var response = await _accountService.SignUp(viewModel);

                //Add Bearer Token in header of response?

                return StatusCode(response.StatusCode, response);
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (RepositoryException ex)
            {
                return StatusCode(500, $"Repository Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

    }
}
