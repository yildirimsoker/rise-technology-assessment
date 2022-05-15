using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Constant;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Application.Common.Model;

namespace RiseTechnology.Application.Persons.Queries.GetPersonsWithPagination
{
    public class GetPersonsWithPaginationQuery : IRequest<PaginatedList<GetPersonsWithPaginationDTO>>
    {
        public int Page { get; set; } = PaginationConstant.DefaultPage;
    }

    public class GetPersonsWithPaginationQueryHandler : IRequestHandler<GetPersonsWithPaginationQuery, PaginatedList<GetPersonsWithPaginationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetPersonsWithPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<GetPersonsWithPaginationDTO>> Handle(GetPersonsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * PaginationConstant.DefaultLimit;
            var take = PaginationConstant.DefaultLimit;  
            var count = await _context.Person.CountAsync();
            var persons = _mapper.Map<List<GetPersonsWithPaginationDTO>>(await _context.Person.Skip(skip).Take(take).OrderByDescending(x => x.Id).ToListAsync());
            PaginatedList<GetPersonsWithPaginationDTO> personPagination = new PaginatedList<GetPersonsWithPaginationDTO>(persons, count, request.Page, PaginationConstant.DefaultLimit);
            return personPagination;

        }
    }
}
