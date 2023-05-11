using Microsoft.Build.Framework;

namespace TransportTimetable.ViewModels.TransportType;

public class TransportTypeForManipulationViewModel
{
    [Required]
    public string Name { get; set; } = null!;
}