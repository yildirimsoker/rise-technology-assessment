using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Exceptions;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _context;

        public DeletePersonCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Person.Include(x => x.PersonContact).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            _context.PersonContact.RemoveRange(entity.PersonContact);
            _context.Person.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
