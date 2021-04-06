using PomoControl.Service.DTO;
using System.Collections.Generic;

namespace PomoControl.API.Utilities
{
    public static class Responses
    {
        public static ResponseServiceDTO ApplicationErrorMessage()
        {
            return new ResponseServiceDTO
            {
                Message = "An ocurred internal error. Please, try again later. ",
                Success = false,
                Data = null
            };
        }

        
        public static ResponseServiceDTO DomainErrorMessage(string message)
        {
            return new ResponseServiceDTO
            {
                Message = message,
                Success = false,
                Data = null
            };
        }
        
        public static ResponseServiceDTO DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResponseServiceDTO
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResponseServiceDTO UnauthorizedErrorMessage(string email)
        {
            return new ResponseServiceDTO
            {
                Message = "This Email and/or Password don't is valid.",
                Success = false,
                Data = new { email }
            };
        }
    }
}
