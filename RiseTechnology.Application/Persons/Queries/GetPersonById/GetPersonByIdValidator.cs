using FluentValidation;

namespace RiseTechnology.Application.Persons.Queries.GetPersonById
{
    public class GetPersonByIdValidator: AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdValidator()
        {
            RuleFor(v => v.Id)
              .GreaterThan(0).WithMessage("Page must be greater than zero.");
        }
    }
}
