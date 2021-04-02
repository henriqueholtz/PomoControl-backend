using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.Account;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ResonseWithTokenDTO> SignIn(SignInViewModel viewModel);
        Task<ResonseWithTokenDTO> SignUp(SignUpViewModel viewModel);
    }
}
