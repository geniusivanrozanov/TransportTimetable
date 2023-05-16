using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.TransportType;

public class TransportTypeViewModel : IViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}