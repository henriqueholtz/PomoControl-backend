using PomoControl.Core;
using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.Token;

namespace PomoControl.Service.Interfaces
{
    public interface ITokenService
    {
        ResponseDTO<string> GenerateToken(TokenViewModel viewModel);
        ResponseDTO<TokenClaimsDTO> GetTokenClaims(string accessToken);
        //UpdateToken
        //RevokeToken
        //Block token
    }
}
