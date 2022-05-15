using FluentValidation;

namespace RiseTechnology.Application.PersonContacts.Commands.DeletePersonContact
{
    public class DeletePersonContactValidator: AbstractValidator<DeletePersonContactCommand>
    {
        public DeletePersonContactValidator()
        {
            RuleFor(v => v.Id)
              .GreaterThan(0).WithMessage("Id must be greater than zero.");
        }
    }
}
