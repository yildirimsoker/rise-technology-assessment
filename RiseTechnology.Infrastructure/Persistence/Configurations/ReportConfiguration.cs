using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Infrastructure.Persistence.Configurations
{
    internal class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TransactionId).IsRequired().HasMaxLength(36);
            builder.Property(x => x.ReportPath).HasMaxLength(256);
            builder.Property(x => x.ReportStatusType).IsRequired()
                                                .HasMaxLength(32)
                                                .HasConversion(x => x.ToString(), x => (ReportStatusType)Enum.Parse(typeof(ReportStatusType), x))
                                                .IsUnicode(false);
            builder.ToTable("Report");
        }
    }
}
