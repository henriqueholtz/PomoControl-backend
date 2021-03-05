using FluentValidation;
using PomoControl.Core.Enums.Messages;

namespace PomoControl.Domain.Validators
{
    public class ScopeValidator : AbstractValidator<Scope>
    {
        public ScopeValidator()
        {
            var Scope = new ErrorMessages("Scope");
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(Scope.Empty)

                .NotNull()
                .WithMessage(Scope.Null);

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

            //Description


            //UserCode
        }
    }
}
