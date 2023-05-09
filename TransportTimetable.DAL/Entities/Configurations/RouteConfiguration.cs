using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTimetable.DAL.Entities.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    private const int NumberMaxLength = 30;
    private const int NameMaxLength = 256;
    
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.Property(r => r.Number)
            .IsRequired()
            .HasMaxLength(NumberMaxLength);

        builder.Property(r => r.Name)
            .HasMaxLength(NameMaxLength);
    }
}