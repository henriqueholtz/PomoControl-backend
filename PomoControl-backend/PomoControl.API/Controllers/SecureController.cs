using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PomoControl.API.CustomAuthorization;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        //[AllowAnonymous]
        public string GetAuthorize() => "Authorize!!";

        [HttpPost]
        [Route("post")]
        [ClaimsAuthorize("Code", "2")]
        [Authorize]
        //[AllowAnonymous]
        public string GetAuthorizePost() => "Authorize POST!!";
    }
}
