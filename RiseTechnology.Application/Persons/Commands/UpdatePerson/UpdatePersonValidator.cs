using FluentValidation;

namespace RiseTechnology.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than zero.");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(32).WithMessage("Name must not exceed 32 characters.");

            RuleFor(v => v.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(32).WithMessage("Surname must not exceed 32 characters.");

            RuleFor(v => v.Company)
                .NotEmpty().WithMessage("Company is required.")
                .MaximumLength(256).WithMessage("Company must not exceed 32 characters.");
        }
    }
}
