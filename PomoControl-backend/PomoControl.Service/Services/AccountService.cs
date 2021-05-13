using AutoMapper;
using EscNet.Shared.Extensions;
using PomoControl.Core.DefaultErrorMessages;
using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Exceptions;
using PomoControl.Core.Helpers;
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
        private readonly CryptographyHelper _cryptographyHelper;
        public AccountService(IMapper mapper, IUserRepository userRepository, ITokenService tokenService, CryptographyHelper cryptographyHelper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<ResonseWithTokenDTO> SignIn(SignInViewModel viewModel)
        {
            try
            {
                //verify if exist user with this email
                var userExists = await _userRepository.GetByEmail(viewModel.Email);
                if (userExists == null)
                    return new ResonseWithTokenDTO(401, viewModel.Email, "", "Don't exists user registratate for this email! You can register.", false);

                if(!userExists.Active)
                    return new ResonseWithTokenDTO(401, viewModel.Email, "", "This user don't is active.", false);

                if (!userExists.Password.Equals(_cryptographyHelper.Encrypt(viewModel.Password.ToBase64())))
                    return new ResonseWithTokenDTO(401, viewModel.Email, "", DefaultErrorMessages.InvalidLogin, false);

                var response = _tokenService.GenerateToken(new TokenViewModel(userExists));

                return new ResonseWithTokenDTO(200, new { }, response.Data, "Login successfully", true);
            }
            catch(RepositoryException ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
            catch(ServiceException ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
            catch(Exception ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
        }

        public async Task<ResonseWithTokenDTO> SignUp(SignUpViewModel viewModel)
        {
            try
            {
                //verify if exist user with this email
                var userExists = await _userRepository.GetByEmail(viewModel.Email);
                if (userExists != null)
                    return new ResonseWithTokenDTO(401, viewModel.Email, "", "There is Already a registration for this email.", false);

                if (String.IsNullOrWhiteSpace(viewModel.Password) || viewModel.Password != viewModel.PasswordVerify)
                    throw new InvalidLoginException("Your password is different from the verification password.");

                viewModel.Password = _cryptographyHelper.Encrypt(viewModel.Password.ToBase64());
                viewModel.PasswordVerify = viewModel.Password;

                var user = _mapper.Map<User>(viewModel);
                user.Validate();

                var userCreated = await _userRepository.Create(user);
                if (userCreated == null)
                    throw new ServiceException("Is was not possible to  register this user");

                //generate JWT 
                var response = _tokenService.GenerateToken(new TokenViewModel(userCreated));
                var acessToken = response.Data;

                var userResponse = new TokenClaimsDTO()
                {
                    Code = userCreated.Code,
                    Email = userCreated.Email,
                    Name = userCreated.Name
                };
                return new ResonseWithTokenDTO(200, new { userResponse}, acessToken, "User created with success!", true);
            }
            catch(InvalidLoginException ex)
            {
                return new ResonseWithTokenDTO(500, ex, ex.Message, "", false);
            }
            catch (RepositoryException ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
            catch (ServiceException ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
            catch (Exception ex)
            {
                return new ResonseWithTokenDTO(500, ex, "", "An error ocurred.", false);
            }
        }
    }
}
