using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.Service.DTO;
using System.Collections.Generic;
using static PomoControl.API.CustomAuthorization;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {

        [HttpGet]
        [Route("claims")]
        [Authorize]
        //[AllowAnonymous]
        public List<ClaimDTO> GetClaims() => GetClaimsUser(HttpContext);

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
