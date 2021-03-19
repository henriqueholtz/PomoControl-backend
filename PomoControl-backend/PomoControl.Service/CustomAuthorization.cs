using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PomoControl.Service.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PomoControl.Service
{
    public class CustomAuthorization
    {
        public static bool ValidateClaimsUser(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type.Equals(claimName) && c.Value.Equals(claimValue));
        }

        public static List<ClaimDTO> GetClaimsUser(HttpContext context, bool itemsIgnore = true)
        {
            var list = context.User.Claims.ToList();
            var listDto = new List<ClaimDTO>();
            List<string> listitemsIgnore = new List<string> 
            { 
                "nbf",
                "exp",
                "iat",
                "iss",
                "aud"
            };
            foreach(var item in list)
            {
                string type = item.Type;
                if (item.Type.Contains("/"))
                {
                    var split = item.Type.Split("/");
                    type = split[split.Length - 1];
                }
                if(!itemsIgnore || !listitemsIgnore.Contains(type))
                    listDto.Add(new ClaimDTO(type, item.Value));
            }
            return listDto;
        }

        public class ClaimsAuthorizeAttribute : TypeFilterAttribute
        {
            public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequirementClaimFilter))
            {
                Arguments = new object[] { new Claim(claimName, claimValue) };
            }
        }
        public class RequirementClaimFilter : IAuthorizationFilter
        {
            private readonly Claim _claim;
            public RequirementClaimFilter(Claim claim)
            {
                _claim = claim;
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (!context.HttpContext.User.Identity.IsAuthenticated)
                {
                    context.Result = new StatusCodeResult(401); //Unautorhized
                }

                if (!CustomAuthorization.ValidateClaimsUser(context.HttpContext, _claim.Type, _claim.Value))
                {
                    context.Result = new StatusCodeResult(403); //Forbidden
                }
            }
        }
    }
}
