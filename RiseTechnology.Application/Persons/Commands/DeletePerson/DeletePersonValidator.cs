using FluentValidation;

namespace RiseTechnology.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than zero.");
        }
    }
}
