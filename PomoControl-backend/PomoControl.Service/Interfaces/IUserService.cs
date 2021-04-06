using PomoControl.Core;
using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.Account;
using PomoControl.Service.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(CreateUserViewModel userViewModel);
        Task<UserDTO> Update(UserDTO userDTO);
        Task<ResponseServiceDTO> ChangeStatus(ChangeStatusViewModel viewModel);
        Task<UserDTO> Get(int code);
        Task<UserDTO> GetByEmail(string email);
        Task<List<UserDTO>> SearchByName(string Name);
    }
}
