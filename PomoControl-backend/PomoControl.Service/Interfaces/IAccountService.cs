using PomoControl.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseDTO> SignIn(AccountDTO accountDTO);
        Task<ResponseDTO> SignUp(AccountDTO accountDTO);
    }
}
