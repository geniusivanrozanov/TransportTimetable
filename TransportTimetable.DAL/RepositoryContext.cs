using Microsoft.EntityFrameworkCore;
using TransportTimetable.DAL.Entities;

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
}