using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TransportTimetable.DAL.Entities;

public class Stop
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    
    public Point Location { get; set; }
    
    public ICollection<RouteStop>? RouteStops { get; set; }
}