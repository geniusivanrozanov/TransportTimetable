using Microsoft.EntityFrameworkCore;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Entities.Configurations;

namespace TransportTimetable.DAL;

public class RepositoryContext : DbContext
{
    public DbSet<Route> Routes { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<TransportType> TransportTypes { get; set; }
    public DbSet<TimeTable> TimeTables { get; set; }

    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        modelBuilder.ApplyConfiguration(new StopConfiguration());
        modelBuilder.ApplyConfiguration(new RouteStopConfiguration());
        modelBuilder.ApplyConfiguration(new TransportTypeConfiguration());
    }
}