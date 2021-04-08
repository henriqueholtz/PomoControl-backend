using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PomoControl.Core;
using PomoControl.Core.Exceptions;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
//using static PomoControl.Service.CustomAuthorization;

namespace PomoControl.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ResponseDTO<string> GenerateToken(TokenViewModel viewModel)
        {
            try
            {
                var secretKey = _configuration["Jwt:SecretKey"];
                var audience = _configuration["Jwt:Audience"];
                var issuer = _configuration["Jwt:Issuer"];
                if (String.IsNullOrWhiteSpace(secretKey) || String.IsNullOrWhiteSpace(audience) || String.IsNullOrWhiteSpace(issuer) /*|| !user.Active*/)
                    throw new ServiceException("Don't is possible generate the token.");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Code", viewModel.Code.ToString()),
                        new Claim(ClaimTypes.Name, viewModel.Name),
                        new Claim(ClaimTypes.Email, viewModel.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new ResponseDTO<string>(tokenHandler.WriteToken(token), "", true);
            }
            catch (ServiceException ex)
            {
                return new ResponseDTO<string>("The JWT Token could not be generared, an exception was thrown: " + ex.Message, false);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<string>("The JWT Token could not be generared, an exception was thrown: " + ex.Message, false);
            }
        }

        public ResponseDTO<TokenClaimsDTO> GetTokenClaims(HttpContext context, bool itemsIgnore = true)
        {
            //var claims = GetClaimsUser(context, itemsIgnore);
            TokenClaimsDTO tokenClaimsDTO = new TokenClaimsDTO();
            //foreach(var claim in claims)
            //{
            //    switch(claim.Type.ToLower())
            //    {
            //        case "code":
            //            tokenClaimsDTO.Code = Convert.ToInt32(claim.Value);
            //            break;

            //        case "name":
            //            tokenClaimsDTO.Name = claim.Value;
            //            break;

            //        case "emailaddress":
            //            tokenClaimsDTO.Email = claim.Value;
            //            break;
            //    }
            //}
            return new ResponseDTO<TokenClaimsDTO>(tokenClaimsDTO, "", true);
        }

        public ResponseDTO<dynamic> GetClaimsFromList(HttpContext context, List<string> claims)
        {
            if (!claims.Any())
                return null;

            //var allClaims = GetClaimsUser(context, true);
            //var result = (from x in allClaims join y in claims on x.Type.ToLower() equals y.ToLower() select x).ToList();
            return new ResponseDTO<dynamic>(new { }, "", true);
        }

        public ResponseDTO<int> GetCode(HttpContext context)
        {
            //var allClaims = GetClaimsUser(context);
            //var claimCode = allClaims.FirstOrDefault(x => x.Type.Equals("Code"));
            int code = 0;
            //if (claimCode == null || !Int32.TryParse(claimCode.Value, out code))
                return new ResponseDTO<int>(0, "", false);
            //return new ResponseDTO<int>(code, "", true);
        }

        public ResponseDTO<string> GetEmail(HttpContext context)
        {
            //var allClaims = GetClaimsUser(context);
            //var claimEmail = allClaims.FirstOrDefault(x => x.Type.Equals("emailaddress"));
            //if (claimEmail == null || String.IsNullOrWhiteSpace(claimEmail.Value))
                return new ResponseDTO<string>("", false);
            //return new ResponseDTO<string>(claimEmail.Value, "", true);
        }
    }
}
