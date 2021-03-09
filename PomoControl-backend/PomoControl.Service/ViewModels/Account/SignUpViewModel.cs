using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace PomoControl.Service.ViewModels.Account
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(2, ErrorMessage = "The minimum length for Name is 2 characters.")]
        [MaxLength(75, ErrorMessage = "The maximum length for Name is 75 characters.")]
        public string Name { get; set; }



        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [RegularExpression(HelperRegex.Email, ErrorMessage = "This Email don't is valid!")]
        [MinLength(6, ErrorMessage = "The minimum length for Email is 6 characters.")]
        [MaxLength(150, ErrorMessage = "The maximum length for Name is 150 characters.")]
        public string Email { get; set; }


        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(8, ErrorMessage = "The minimum length for Passowrd is 8 characters.")]
        [MaxLength(130, ErrorMessage = "The maximum length for Passowrd is 130 characters.")]
        [RegularExpression(HelperRegex.Password, ErrorMessage = "This Email and/or Password don't is valid.")]
        public string Password { get; set; }


        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(8, ErrorMessage = "The minimum length for Passowrd Verify is 8 characters.")]
        [MaxLength(130, ErrorMessage = "The maximum length for Passowrd Verify is 130 characters.")]
        [RegularExpression(HelperRegex.Password, ErrorMessage = "This Email and/or Password don't is valid.")]
        public string PasswordVerify { get; set; }
        //public bool Active { get; } = true;
        //public DateTime RegisteredDate { get; } = DateTime.Now;
    }
}
