using Microsoft.EntityFrameworkCore;
using RiseTechnology.Application.Common.Interfaces;
using RiseTechnology.Domain.Entities;
using RiseTechnology.Infrastructure.Persistence.Configurations;
using RiseTechnology.Infrastructure.Persistence.Seed;

namespace RiseTechnology.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person => Set<Person>();
        public DbSet<PersonContact> PersonContact => Set<PersonContact>();
        public DbSet<Report> Report => Set<Report>();
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonContactConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new PersonSeed());
            modelBuilder.ApplyConfiguration(new PersonContactSeed());
            base.OnModelCreating(modelBuilder);
        }
    }
}
