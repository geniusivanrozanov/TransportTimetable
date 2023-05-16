using System.ComponentModel.DataAnnotations;
using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.Stop;

public class StopViewModelForCreation : IViewModelForCreation
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public double? X { get; set; }
    
    [Required]
    [Range(-90, 90)]
    public double? Y { get; set; }
}