using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.Route;

public class RouteViewModel : IViewModel
{
    public Guid Id { get; set; }
    
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    public string? TransportType { get; set; }
}