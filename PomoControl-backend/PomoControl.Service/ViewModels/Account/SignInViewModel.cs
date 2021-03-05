using PomoControl.Core.Enums.Messages;
using System.ComponentModel.DataAnnotations;

namespace PomoControl.Service.ViewModels.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "This Email don't is valid!")]
        [MinLength(6, ErrorMessage = "The minimum length for Email is 6 characters.")]
        [MaxLength(150, ErrorMessage = "The maximum length for Name is 150 characters.")]
        public string Email { get; set; }


        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(10, ErrorMessage = "The minimum length for Passowrd is 10 characters.")]
        [MaxLength(130, ErrorMessage = "The maximum length for Passowrd is 130 characters.")]
        public string Password { get; set; }
    }
}
