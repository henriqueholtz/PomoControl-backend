using FluentValidation;
using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Helpers;

namespace PomoControl.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly ErrorMessages _user = new ErrorMessages("User");
        private readonly ErrorMessages _name = new ErrorMessages("Name");
        private readonly ErrorMessages _email = new ErrorMessages("Email");
        private readonly ErrorMessages _password = new ErrorMessages("Password");
        private readonly ErrorMessages _passwordVerify = new ErrorMessages("Password Verify");
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(_user.NotEmpty)

                .NotNull()
                .WithMessage(_user.NotNull);

            //Name
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(_name.NotNull)

                .NotEmpty()
                .WithMessage(_name.EmptyMethod())

                .MinimumLength(3)
                .WithMessage(_name.MaximumLength(3))

                .MaximumLength(75)
                .WithMessage(_name.MaximumLength(75));

            //Email
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(_email.NotNull)

                .NotEmpty()
                .WithMessage(_email.NotEmpty)

                .MinimumLength(10)
                .WithMessage(_email.MinimumLength(10))

                .MaximumLength(180)
                .WithMessage(_email.MaximumLength(180))

                .Matches(HelperRegex.EmailRegex)
                .WithMessage(_email.NotValid);

            //Password
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(_password.NotNull)

                .NotEmpty()
                .WithMessage(_password.NotEmpty)

                .MinimumLength(8)
                .WithMessage(_password.MinimumLength(8))

                .MaximumLength(300)
                .WithMessage(_password.MaximumLength(300));


            //PasswordVerify
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(_passwordVerify.NotNull)

                .NotEmpty()
                .WithMessage(_passwordVerify.NotEmpty)

                .MinimumLength(8)
                .WithMessage(_passwordVerify.MinimumLength(8))

                .MaximumLength(300)
                .WithMessage(_passwordVerify.MaximumLength(300));

            //Active
        }
    }
}
