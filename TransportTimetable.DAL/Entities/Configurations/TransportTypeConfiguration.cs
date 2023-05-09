using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTimetable.DAL.Entities.Configurations;

public class TransportTypeConfiguration : IEntityTypeConfiguration<TransportType>
{
    private const int NameMaxLength = 256;
    
    public void Configure(EntityTypeBuilder<TransportType> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength);
    }
}