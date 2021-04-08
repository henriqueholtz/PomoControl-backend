using AutoMapper;
using PomoControl.Core.Exceptions;
using PomoControl.Domain;
using PomoControl.Infraestructure.Interfaces;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Account;
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

        public async Task<ResponseServiceDTO> ChangeStatus(ChangeStatusViewModel viewModel)
        {
            try
            {
                var userExist = await _userRepository.GetByEmail(viewModel.Email);
                if (userExist == null)
                    throw new DomainException("This Email don't is registered"); //Warning here

                if(viewModel != null && viewModel.Active.Equals(userExist.Active))
                {
                    return new ResponseServiceDTO(200, _mapper.Map<UserSimpleDTO>(userExist), "Success! Your user already had this status.", true);
                }
                
                var response = await _userRepository.ChangeStatus(userExist, viewModel.Active);
                if (response.Success)
                {
                    return new ResponseServiceDTO(200, _mapper.Map<UserSimpleDTO>(userExist), "Success! Your user has been updated (Status only).", true);
                }
                return new ResponseServiceDTO(500, viewModel, $"An error ocurred: {response.Message}", false);
            }
            catch (PomoControlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public /*async*/ Task<UserDTO> Create(CreateUserViewModel userViewModel)
        {
            //try
            //{
            //    var userExist = await _userRepository.GetByEmail(userViewModel.Email);
            //    if (userExist != null)
            //        throw new DomainException("There is already a user with that email! Please login.");

            //    var user = _mapper.Map<User>(userViewModel);
            //    user.Validate();
            //    var userCreated = await _userRepository.Create(user);
            //    return _mapper.Map<UserDTO>(userCreated);
            //}
            //catch (DomainException ex)
            //{
            //    throw new DomainException(ex.Message, ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new ServiceException("Ocurred an error on create User! Try again later.", ex);
            //}
            throw new NotImplementedException();
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
