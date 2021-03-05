using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : PomoController
    {

        [HttpGet]
        [Authorize]
        //[AllowAnonymous]
        public string GetAuthorize() => "Authorize!!";

        [HttpPost]
        [Route("post")]
        [Authorize]
        //[AllowAnonymous]
        public string GetAuthorizePost() => "Authorize POST!!";
    }
}
