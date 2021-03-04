using FluentValidation;
using PomoControl.Core.Enums.Messages;

namespace PomoControl.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ErrorMessagesEntity<User>.Empty)
                //.WithMessage("This entity cannot be empty.")

                .NotNull()
                .WithMessage(ErrorMessagesEntity<User>.Null);
                //.WithMessage("This entity cannot be null.");

            //Name
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(new ErrorMessagesProperty("Name").Null)
                //.WithMessage("The Name cannot be null.")

                .NotEmpty()
                .WithMessage(new ErrorMessagesProperty("Name").EmptyMethod())
                //.WithMessage("The Name cannot be empty.")

                .MinimumLength(3)
                .WithMessage(new ErrorMessagesProperty("Name").MaximumLength(3))

                .MaximumLength(75)
                .WithMessage(new ErrorMessagesProperty("Name").MaximumLength(75));

            //Email

            //Password

            //PasswordVerify
        }
    }
}
