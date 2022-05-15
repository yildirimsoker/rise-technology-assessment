using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Exceptions;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Reports.Queries.GetReportsByTransactionId
{
    public class GetReportsByTransactionIdQuery : IRequest<GetReportsByTransactionIdDTO>
    {
        public string? TransactionId { get; set; }
    }

    public class GetReportsByTransactionIdQueryHandler : IRequestHandler<GetReportsByTransactionIdQuery, GetReportsByTransactionIdDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetReportsByTransactionIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetReportsByTransactionIdDTO> Handle(GetReportsByTransactionIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Report.FirstOrDefaultAsync(x => x.TransactionId == request.TransactionId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Report), request.TransactionId!);
            }

            return _mapper.Map<GetReportsByTransactionIdDTO>(entity);
        }
    }
}
