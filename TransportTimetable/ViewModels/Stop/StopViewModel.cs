using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.Stop;

public class StopViewModel : IViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public double X { get; set; }
    
    public double Y { get; set; }
}