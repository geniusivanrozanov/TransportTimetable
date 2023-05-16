namespace TransportTimetable.DAL.Entities;

public class Route : GuidEntity
{
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    public Guid TransportTypeId { get; set; }
    public TransportType? TransportType { get; set; }
    
    public ICollection<RouteStop>? RouteStops { get; set; }
}