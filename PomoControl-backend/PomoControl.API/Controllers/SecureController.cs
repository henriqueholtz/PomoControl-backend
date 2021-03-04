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

        [HttpPost("/post")]
        //[Route("/post")]
        [Authorize]
        //[AllowAnonymous]
        public string GetAuthorizePost() => "Authorize POST!!";

        //[HttpGet]
        //[Authorize]
        //public object Secure([FromQuery]string accessToken)
        //{
        //    //var stream = "[encoded jwt]";
        //    var handler = new JwtSecurityTokenHandler();
        //    var jsonToken = handler.ReadToken(accessToken);
        //    var tokenS = handler.ReadToken(accessToken) as JwtSecurityToken; 


        //    return new { tokenS };
        //}
    }
}
