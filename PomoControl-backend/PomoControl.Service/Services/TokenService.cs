using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PomoControl.Core;
using PomoControl.Core.Exceptions;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Token;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                return new ResponseDTO<string>(tokenHandler.WriteToken(token));
            }
            catch (ServiceException ex)
            {
                return new ResponseDTO<string>("The JWT Token could not be generared, an exception was thrown: " + ex.Message);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<string>("The JWT Token could not be generared, an exception was thrown: " + ex.Message);
            }
        }

        public ResponseDTO<TokenClaimsDTO> GetTokenClaims(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
