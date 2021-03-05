using PomoControl.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task<UserDTO> ChangeStatus(int code);
        Task<UserDTO> Get(int code);
        Task<UserDTO> GetByEmail(string email);
        Task<List<UserDTO>> SearchByName(string Name);
    }
}
