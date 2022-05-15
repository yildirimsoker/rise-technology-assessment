using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Exceptions;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Persons.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<GetPersonByIdDTO>
    {
        public int Id { get; set; }
    }

    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, GetPersonByIdDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetPersonByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetPersonByIdDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Person.Include(x => x.PersonContact).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return _mapper.Map<GetPersonByIdDTO>(entity);
        }
    }
}
