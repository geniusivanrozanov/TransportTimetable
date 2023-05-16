using Microsoft.Build.Framework;

namespace TransportTimetable.ViewModels.TransportType;

public class TransportTypeViewModelForManipulation
{
    [Required]
    public string Name { get; set; } = null!;
}