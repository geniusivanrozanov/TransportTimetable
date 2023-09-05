using TransportTimetable.Interfaces;
using TransportTimetable.ViewModels.Route;

namespace TransportTimetable.ViewModels.Stop;

public class StopWithRoutesViewModel : IViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public double X { get; set; }
    
    public double Y { get; set; }
    
    public ICollection<RouteViewModel>? Routes { get; set; }
}