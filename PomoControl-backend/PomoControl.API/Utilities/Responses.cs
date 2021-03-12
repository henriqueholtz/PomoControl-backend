﻿using PomoControl.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Utilities
{
    public static class Responses
    {
        public static ResponseDTO ApplicationErrorMessage()
        {
            return new ResponseDTO
            {
                Message = "An ocurred internal error. Please, try again later. ",
                Success = false,
                Data = null
            };
        }

        
        public static ResponseDTO DomainErrorMessage(string message)
        {
            return new ResponseDTO
            {
                Message = message,
                Success = false,
                Data = null
            };
        }
        
        public static ResponseDTO DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResponseDTO
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResponseDTO UnauthorizedErrorMessage()
        {
            return new ResponseDTO
            {
                Message = "This Email and/or Password don't is valid.",
                Success = false,
                Data = null
            };
        }
    }
}