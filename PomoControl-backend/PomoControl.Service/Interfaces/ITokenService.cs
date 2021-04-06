using Microsoft.AspNetCore.Http;
using PomoControl.Core;
using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.Token;
using System.Collections.Generic;

namespace PomoControl.Service.Interfaces
{
    public interface ITokenService
    {
        ResponseDTO<string> GenerateToken(TokenViewModel viewModel);
        ResponseDTO<TokenClaimsDTO> GetTokenClaims(HttpContext context, bool itemsIgnore = true);
        ResponseDTO<dynamic> GetClaimsFromList(HttpContext context, List<string> claims);
        ResponseDTO<int> GetCode(HttpContext context);
        ResponseDTO<string> GetEmail(HttpContext context);
        //UpdateToken
        //RevokeToken
        //Block token
    }
}
