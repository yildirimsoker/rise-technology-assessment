using FluentValidation;

namespace RiseTechnology.Application.Persons.Queries.GetPersonsWithPagination
{
    public class GetPersonsWithPaginationValidator : AbstractValidator<GetPersonsWithPaginationQuery>
    {
        public GetPersonsWithPaginationValidator()
        {
           RuleFor(v => v.Page)
             .GreaterThan(0).WithMessage("Page must be greater than zero.");
        }
    }
}
