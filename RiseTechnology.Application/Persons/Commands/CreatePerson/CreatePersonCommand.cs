using AutoMapper;
using MediatR;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _context;

        public CreatePersonCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person entity = _mapper.Map<Person>(request);
            await _context.Person.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
