using Microsoft.EntityFrameworkCore;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Common.Interfaces
{
    public interface  IApplicationDbContext
    {
        DbSet<Person> Person { get; }
        DbSet<PersonContact> PersonContact { get; }
        DbSet<Report> Report { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
