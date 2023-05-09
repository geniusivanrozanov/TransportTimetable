using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTimetable.DAL.Entities.Configurations;

public class StopConfiguration : IEntityTypeConfiguration<Stop>
{
    private const int NameMaxLength = 256;
    
    public void Configure(EntityTypeBuilder<Stop> builder)
    {
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength);

        builder.Property(s => s.Location)
            .IsRequired();
    }
}