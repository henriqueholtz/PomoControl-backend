using FluentValidation;
using PomoControl.Core.Enums.Messages;

namespace PomoControl.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            var User = new ErrorMessages("User");
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(User.Empty)

                .NotNull()
                .WithMessage(User.Null);

            //Name
            var Name = new ErrorMessages("Name");
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(Name.Null)

                .NotEmpty()
                .WithMessage(Name.EmptyMethod())

                .MinimumLength(3)
                .WithMessage(Name.MaximumLength(3))

                .MaximumLength(75)
                .WithMessage(Name.MaximumLength(75));

            //Email
            var Email = new ErrorMessages("Email");

            //Password

            //PasswordVerify

            //Active
        }
    }
}
