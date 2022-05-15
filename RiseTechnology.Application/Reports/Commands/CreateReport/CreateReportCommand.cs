using MediatR;
using Newtonsoft.Json;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Application.Reports.Commands.ComplateReport;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Reports.Commands.CreateReport
{
    public class CreateReportCommand : IRequest<string>
    {
    }

    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMessageService _messageService;

        public CreateReportCommandHandler(IApplicationDbContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        public async Task<string> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            Report entity = new Report();
            entity.RequestDate = DateTime.UtcNow;
            entity.TransactionId = Guid.NewGuid().ToString();
            entity.ReportStatusType = ReportStatusType.New;
            await _context.Report.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var jsonRequest = JsonConvert.SerializeObject(new ComplateReportCommand { Id = entity.Id });
            _messageService.Enqueue(jsonRequest);

            return entity.TransactionId;
        }
    }
}
