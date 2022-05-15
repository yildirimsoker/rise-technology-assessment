using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Reports.Commands.ComplateReport
{
    public class ComplateReportCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class ComplateReportCommandHandler : IRequestHandler<ComplateReportCommand>
    {
        private readonly IApplicationDbContext _context;

        public ComplateReportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ComplateReportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Report.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                try
                {
                    entity.ReportStatusType = ReportStatusType.Handle;
                    await _context.SaveChangesAsync(cancellationToken);

                    var personCountByLocation = _context.PersonContact
                        .Where(x => x.ContactType == ContactType.Location)
                        .GroupBy(x => new { x.ContactDescription, x.ContactType })
                        .Select(g => new { g.Key.ContactDescription, g.Key.ContactType, Count = g.Count() });

                    //Export Excel Code.....................

                    //Update Dummy Path......................
                    entity.ReportPath = "DummyExcelPath/" + entity.TransactionId;
                    entity.ReportStatusType = ReportStatusType.Complate;
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch 
                {
                    entity.ReportStatusType = ReportStatusType.Fail;
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return Unit.Value;
        }
    }

}
