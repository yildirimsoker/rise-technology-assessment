using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Constant;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Application.Common.Model;

namespace RiseTechnology.Application.Reports.Queries.GetReportsWithPagination
{
    public class GetReportsWithPaginationQuery : IRequest<PaginatedList<GetReportsWithPaginationDTO>>
    {
        public int Page { get; set; } = PaginationConstant.DefaultPage;
    }

    public class GetReportsWithPaginationQueryHandler : IRequestHandler<GetReportsWithPaginationQuery, PaginatedList<GetReportsWithPaginationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetReportsWithPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<PaginatedList<GetReportsWithPaginationDTO>> Handle(GetReportsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * PaginationConstant.DefaultLimit;
            var take = PaginationConstant.DefaultLimit;
            var count = await _context.Report.CountAsync();
            var reports = _mapper.Map<List<GetReportsWithPaginationDTO>>(await _context.Report.Skip(skip).Take(take).OrderByDescending(x => x.Id).ToListAsync());
            PaginatedList<GetReportsWithPaginationDTO> personPagination = new PaginatedList<GetReportsWithPaginationDTO>(reports, count, request.Page, PaginationConstant.DefaultLimit);
            return personPagination;
        }
    }
}
