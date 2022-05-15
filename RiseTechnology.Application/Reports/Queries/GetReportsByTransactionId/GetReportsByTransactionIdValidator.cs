using FluentValidation;

namespace RiseTechnology.Application.Reports.Queries.GetReportsByTransactionId
{
    public class GetReportsByTransactionIdValidator : AbstractValidator<GetReportsByTransactionIdQuery>
    {
        public GetReportsByTransactionIdValidator()
        {
            RuleFor(v => v.TransactionId).NotEmpty().WithMessage("TransactionId is required.");
        }
    }
}
