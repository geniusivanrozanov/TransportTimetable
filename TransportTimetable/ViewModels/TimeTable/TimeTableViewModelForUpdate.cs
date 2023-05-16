using Microsoft.Build.Framework;
using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.TimeTable;

public class TimeTableViewModelForUpdate : IViewModelForUpdate
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public int Hours { get; set; }
    
    [Required]
    public int Minutes { get; set; }
    
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    
    [Required]
    public Guid? RouteId { get; set; }
    
    [Required]
    public Guid? StopId { get; set; }
}