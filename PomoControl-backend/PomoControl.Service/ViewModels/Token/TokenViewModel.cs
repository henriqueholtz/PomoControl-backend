using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PomoControl.Service.ViewModels.Token
{
    public class TokenViewModel
    {
        public TokenViewModel(PomoControl.Domain.User user)
        {
            user.Validate();
            if (!user.Errors.Any())
            {
                Code = user.Code;
                Name = user.Name;
                Email = user.Email;
            }
        }

        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [Range(1, (double)int.MaxValue, ErrorMessage = "Code must be greater than zero.")]
        public int Code { get; private set; }


        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [MinLength(2, ErrorMessage = "The minimum length for Name is 2 characters.")]
        [MaxLength(75, ErrorMessage = "The maximum length for Name is 75 characters.")]
        public string Name { get; private set; }



        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [RegularExpression(HelperRegex.Email, ErrorMessage = "This Email don't is valid!")]
        [MinLength(6, ErrorMessage = "The minimum length for Email is 6 characters.")]
        [MaxLength(150, ErrorMessage = "The maximum length for Name is 150 characters.")]
        public string Email { get; private set; }

    }
}
