using TransportTimetable.Interfaces;
using TransportTimetable.ViewModels.Stop;

namespace TransportTimetable.ViewModels.Route;

public class RouteWithStopsViewModel : IViewModel
{
    public Guid Id { get; set; }
    
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    public string? TransportType { get; set; }
    
    public ICollection<StopViewModel>? Stops { get; set; }
}