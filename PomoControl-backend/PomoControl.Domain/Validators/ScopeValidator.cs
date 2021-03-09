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
                .WithMessage(Scope.NotEmpty)

                .NotNull()
                .WithMessage(Scope.NotNull);

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

            //Description
            var Description = new ErrorMessages("Description");


            //UserCode
        }
    }
}
