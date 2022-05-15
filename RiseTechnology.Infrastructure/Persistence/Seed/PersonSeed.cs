using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Infrastructure.Persistence.Seed
{
    internal class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person { 
                    Id = 1, 
                    Name = "Yildirim", 
                    Surname = "Soker", 
                    Company = "Ys Company"
                });

            builder.HasData(
                new Person
                {
                    Id = 2,
                    Name = "Ali",
                    Surname = "Veli",
                    Company = "AV Company"
                });
        }
    }
}
