using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace TransportTimetable.DAL.Entities;

public class Stop
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Point Location { get; set; } = null!;
    
    public ICollection<RouteStop>? RouteStops { get; set; }
}