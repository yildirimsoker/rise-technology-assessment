using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Exceptions;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.PersonContacts.Commands.DeletePersonContact
{
    public class DeletePersonContactCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePersonContactCommandHandler : IRequestHandler<DeletePersonContactCommand>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _context;

        public DeletePersonContactCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePersonContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonContact.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PersonContact), request.Id);
            }
            _context.PersonContact.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
