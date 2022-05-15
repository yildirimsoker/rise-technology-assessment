using Microsoft.AspNetCore.Mvc;
using RiseTechnology.Application.Common.Model;
using RiseTechnology.Application.Reports.Commands.CreateReport;
using RiseTechnology.Application.Reports.Queries.GetReportsByTransactionId;
using RiseTechnology.Application.Reports.Queries.GetReportsWithPagination;

namespace RiseTechnology.API.Controllers
{
    [Route("api/report")]
    public class ReportController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create()
        {
            return await Mediator.Send(new CreateReportCommand());
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetReportsWithPaginationDTO>>> GetAll([FromQuery] GetReportsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        [Route("transaction")]
        public async Task<ActionResult<GetReportsByTransactionIdDTO>> GetByTransactionId([FromQuery] GetReportsByTransactionIdQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
