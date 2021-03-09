using PomoControl.Core;
using PomoControl.Domain;
using PomoControl.Service.ViewModels.Token;

namespace PomoControl.Service.Interfaces
{
    public interface ITokenService
    {
        ResponseDTO<string> GenerateToken(TokenViewModel viewModel);
        //UpdateToken
        //RevokeToken
    }
}
