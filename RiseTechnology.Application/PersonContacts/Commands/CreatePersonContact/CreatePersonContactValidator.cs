using FluentValidation;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.PersonContacts.Commands.CreatePersonContact
{
    public class CreatePersonContactValidator : AbstractValidator<CreatePersonContactCommand>
    {
        public CreatePersonContactValidator()
        {
            RuleFor(v => v.PersonId)
                .GreaterThan(0).WithMessage("PersonId must be greater than zero.");

            RuleFor(v => v.ContactType)
                .NotEmpty().WithMessage("ContactType is required.")
                .Must(x => x.Equals(ContactType.Email.ToString()) ||
                           x.Equals(ContactType.Location.ToString())|| 
                           x.Equals(ContactType.PhoneNumber.ToString()))
                .WithMessage("You can only use for Email, Location and PhoneNumber.");

            RuleFor(v => v.ContactDescription)
                .NotEmpty().WithMessage("ContactDescription is required.")
                .MaximumLength(512).WithMessage("ContactDescription must not exceed 512 characters.");

        }
    }
}
