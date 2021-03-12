using AutoMapper;
using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Exceptions;
using PomoControl.Domain;
using PomoControl.Infraestructure.Interfaces;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Account;
using PomoControl.Service.ViewModels.Token;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public AccountService(IMapper mapper, IUserRepository userRepository, ITokenService tokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<ResponseDTO> SignIn(SignInViewModel viewModel)
        {
            try
            {
                //verify if exist user with this email
                var userExists = await _userRepository.GetByEmail(viewModel.Email);
                if (userExists == null)
                    return new ResponseDTO(401, viewModel.Email, "Don't exists user registratate for this email! You can register.", false);

                if(!userExists.Active)
                    return new ResponseDTO(401, viewModel.Email, "This user don't is active.", false);

                if (!userExists.ValidatePassword(viewModel.Password))
                    return new ResponseDTO(401, viewModel.Email, ErrorMessagesStatic.IncorretLogin, false);

                var response = _tokenService.GenerateToken(new TokenViewModel(userExists));

                return new ResponseDTO(200, response.Data, response.Message, true);
            }
            catch(RepositoryException ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
            catch(ServiceException ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
            catch(Exception ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
        }

        public async Task<ResponseDTO> SignUp(SignUpViewModel viewModel)
        {
            try
            {
                //verify if exist user with this email
                var userExists = await _userRepository.GetByEmail(viewModel.Email);
                if (userExists != null)
                    return new ResponseDTO(401, viewModel, "There is Already a registration for this email.", false);

                var user = _mapper.Map<User>(viewModel);
                user.Validate();

                //Password transform to save in database
                if (!user.PasswordTransform())
                    throw new DomainException("An or more errors ocurred.", user.Errors.ToList());

                var userCreated = await _userRepository.Create(user);
                if (userCreated == null)
                    throw new ServiceException("Is was not possible to  register this user");

                //generate JWT 
                var response = _tokenService.GenerateToken(new TokenViewModel(userCreated));
                var acessToken = response.Data;

                return new ResponseDTO(200, new { userCreated, acessToken }, "User created with success!", true);
            }
            catch (RepositoryException ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
            catch (ServiceException ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
            catch (Exception ex)
            {
                return new ResponseDTO(500, ex, "An error ocurred.", false);
            }
        }
    }
}
