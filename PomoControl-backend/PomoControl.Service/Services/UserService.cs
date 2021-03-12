using AutoMapper;
using PomoControl.Core.Exceptions;
using PomoControl.Domain;
using PomoControl.Infraestructure.Interfaces;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<UserDTO> ChangeStatus(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Create(CreateUserViewModel userViewModel)
        {
            try
            {
                var userExist = await _userRepository.GetByEmail(userViewModel.Email);
                if (userExist != null)
                    throw new DomainException("There is already a user with that email! Please login.");

                var user = _mapper.Map<User>(userViewModel);
                user.Validate();
                var userCreated = await _userRepository.Create(user);
                return _mapper.Map<UserDTO>(userCreated);
            }
            catch (DomainException ex)
            {
                throw new DomainException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Ocurred an error on create User! Try again later.", ex);
            }
        }

        public Task<UserDTO> Get(int code)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> SearchByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
