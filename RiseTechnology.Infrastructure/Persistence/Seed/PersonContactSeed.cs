using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Infrastructure.Persistence.Seed
{
    internal class PersonContactSeed:  IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.HasData(
                new PersonContact
                {
                    Id = 1,
                    PersonId = 1,
                    ContactDescription = "yildirimsoker@gmail.com",
                    ContactType = ContactType.Email
                });

            builder.HasData(
                new PersonContact
                {
                    Id = 2,
                    PersonId = 1,
                    ContactDescription = "05380867056",
                    ContactType = ContactType.PhoneNumber
                });

            builder.HasData(
                new PersonContact
                {
                    Id = 3,
                    PersonId = 1,
                    ContactDescription = "27.814786,22.053289",
                    ContactType = ContactType.Location
                });



            builder.HasData(
                new PersonContact
                {
                    Id = 4,
                    PersonId = 2,
                    ContactDescription = "aliveli@gmail.com",
                    ContactType = ContactType.Email
                });

            builder.HasData(
                new PersonContact
                {
                    Id = 5,
                    PersonId = 2,
                    ContactDescription = "05422305462",
                    ContactType = ContactType.PhoneNumber
                });
            builder.HasData(
                new PersonContact
                {
                    Id = 6,
                    PersonId = 2,
                    ContactDescription = "39.482845,60.399189",
                    ContactType = ContactType.Location
                });
        }
    }
}
