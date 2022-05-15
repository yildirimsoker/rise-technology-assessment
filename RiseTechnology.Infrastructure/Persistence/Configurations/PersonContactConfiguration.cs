using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Infrastructure.Persistence.Configurations
{
    internal class PersonContactConfiguration : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ContactDescription).IsRequired().HasMaxLength(512);
            builder.Property(x => x.ContactType).IsRequired()
                                                .HasMaxLength(32)
                                                .HasConversion(x => x.ToString(), x => (ContactType)Enum.Parse(typeof(ContactType), x))
                                                .IsUnicode(false);
            builder.ToTable("PersonContact");
        }
    }
}
