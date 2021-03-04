using FluentValidation;

namespace PomoControl.Domain.Validators
{
    public class ScopeValidator : AbstractValidator<Scope>
    {
        public ScopeValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("This entity cannot be empty.")

                .NotNull()
                .WithMessage("This entity cannot be null.");

            //Name
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("The Name cannot be null.")

                .NotEmpty()
                .WithMessage("The Name cannot be empty.")

                .MinimumLength(3)
                .WithMessage("The minimum length for Name is 3 characters.")

                .MaximumLength(75)
                .WithMessage("The maximum length for Name is 75 characters.");

            //Description


            //UserCode
        }
    }
}
