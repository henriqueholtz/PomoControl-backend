using AutoMapper;
using PomoControl.Infraestructure.Interfaces;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace PomoControl.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public async Task<ResponseDTO> SignIn(AccountDTO accountDTO)
        {
            //verify if exist user with this email
            var user = await _userRepository.GetByEmail(accountDTO.Email);
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> SignUp(AccountDTO accountDTO)
        {
            //verify if exist user with this email
            var user = await _userRepository.GetByEmail(accountDTO.Email);
            throw new NotImplementedException();
        }
    }
}
