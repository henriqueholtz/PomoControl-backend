using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.Account;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseDTO> SignIn(SignInViewModel viewModel);
        Task<ResponseDTO> SignUp(SignUpViewModel viewModel);
    }
}
