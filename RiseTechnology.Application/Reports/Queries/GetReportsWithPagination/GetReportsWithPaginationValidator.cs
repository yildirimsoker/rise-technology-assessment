using FluentValidation;

namespace RiseTechnology.Application.Reports.Queries.GetReportsWithPagination
{
    public class GetReportsWithPaginationValidator: AbstractValidator<GetReportsWithPaginationQuery>
    {
        public GetReportsWithPaginationValidator()
        {
            RuleFor(v => v.Page)
              .GreaterThan(0).WithMessage("Page must be greater than zero.");
        }
    }
}
