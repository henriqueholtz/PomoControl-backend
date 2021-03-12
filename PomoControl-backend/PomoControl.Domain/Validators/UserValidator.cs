using FluentValidation;
using PomoControl.Core.Enums.Messages;
using PomoControl.Core.Helpers;

namespace PomoControl.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            var User = new ErrorMessages("User");
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(User.NotEmpty)

                .NotNull()
                .WithMessage(User.NotNull);

            //Name
            var Name = new ErrorMessages("Name");
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(Name.NotNull)

                .NotEmpty()
                .WithMessage(Name.EmptyMethod())

                .MinimumLength(3)
                .WithMessage(Name.MaximumLength(3))

                .MaximumLength(75)
                .WithMessage(Name.MaximumLength(75));

            //Email
            var Email = new ErrorMessages("Email");
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(Email.NotNull)

                .NotEmpty()
                .WithMessage(Email.NotEmpty)

                .MinimumLength(10)
                .WithMessage(Email.MinimumLength(10))

                .MaximumLength(180)
                .WithMessage(Email.MaximumLength(180))

                .Matches(HelperRegex.EmailRegex)
                .WithMessage(Email.NotValid);

            //Password
            var Password = new ErrorMessages("Password");
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(Password.NotNull)

                .NotEmpty()
                .WithMessage(Password.NotEmpty)

                .MinimumLength(8)
                .WithMessage(Password.MinimumLength(8))

                .MaximumLength(80)
                .WithMessage(Password.MaximumLength(80))

                .Matches(HelperRegex.PasswordRegex)
                .WithMessage(ErrorMessagesStatic.IncorretLogin)

                .Equal(y => y.PasswordVerify)
                .WithMessage("Password and Password Verify are different.");



            //PasswordVerify
            var PasswordVerify = new ErrorMessages("Password Verify");
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(PasswordVerify.NotNull)

                .NotEmpty()
                .WithMessage(PasswordVerify.NotEmpty)

                .MinimumLength(8)
                .WithMessage(PasswordVerify.MinimumLength(8))

                .MaximumLength(80)
                .WithMessage(PasswordVerify.MaximumLength(80))

                .Matches(HelperRegex.PasswordRegex)
                .WithMessage(ErrorMessagesStatic.IncorretLogin);

            //Active
        }
    }
}
