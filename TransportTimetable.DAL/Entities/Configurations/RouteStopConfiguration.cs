using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTimetable.DAL.Entities.Configurations;

public class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        builder.HasIndex(rs => new
            {
                rs.RouteId,
                rs.Order
            })
            .IsUnique();
    }
}