﻿using PomoControl.Core.DefaultErrorMessages;
using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PomoControl.Service.ViewModels.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [RegularExpression(HelperRegex.EmailRegex, ErrorMessage = DefaultErrorMessages.InvalidLogin)]
        [MinLength(6, ErrorMessage = "The minimum length for Email is 6 characters.")]
        [MaxLength(150, ErrorMessage = "The maximum length for Name is 150 characters.")]
        public string Email { get; set; }


        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(8, ErrorMessage = "The minimum length for Passowrd is 8 characters.")]
        [MaxLength(130, ErrorMessage = "The maximum length for Passowrd is 130 characters.")]
        [RegularExpression(HelperRegex.PasswordRegex, ErrorMessage = DefaultErrorMessages.InvalidLogin)]
        public string Password { get; set; }
    }
}
