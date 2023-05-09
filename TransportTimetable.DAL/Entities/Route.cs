using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportTimetable.DAL.Entities;

public class Route
{
    public Guid Id { get; set; }
    
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    public Guid TransportTypeId { get; set; }
    public TransportType? TransportType { get; set; }
    
    public ICollection<RouteStop>? RouteStops { get; set; }
}