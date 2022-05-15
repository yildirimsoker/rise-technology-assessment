using AutoMapper;
using MediatR;
using RiseTechnology.Application.Common.Exceptions;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.PersonContacts.Commands.CreatePersonContact
{
    public class CreatePersonContactCommand : IRequest<int>
    {
        public int PersonId { get; set; }
        public string? ContactType { get; set; }
        public string? ContactDescription { get; set; }
        
    }

    public class CreatePersonContactCommandHandler : IRequestHandler<CreatePersonContactCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _context;

        public CreatePersonContactCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Person.FindAsync(new object[] { request.PersonId }, cancellationToken);

            if (person == null)
            {
                throw new NotFoundException(nameof(Person), request.PersonId);
            }
            PersonContact entity = _mapper.Map<PersonContact>(request);
            await _context.PersonContact.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
